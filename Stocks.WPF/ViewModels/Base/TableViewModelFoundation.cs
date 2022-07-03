using Stocks.EntityFramework.Date;
using Stocks.EntityFramework.Models;
using Stocks.EntityFramework.Models.Base;
using Stocks.WPF.Infrastructures;
using Stocks.WPF.Infrastructures.Commands;
using Stocks.WPF.Infrastructures.Commands.Base;
using Stocks.WPF.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace Stocks.WPF.ViewModels.Base
{
    internal class TableViewModelFoundation<TModel> : ViewModel
        where TModel : BaseEntity, new()
    {
        protected readonly StocksDbContextFactory _stocksDbContextFactory;
        protected ObservableCollection<TModel> _allItems;        
        protected List<int> _updatedItemsIds;
        protected string _filter;

        private ObservableCollection<TModel> _items;
        private TModel _selectedItem;

        public TModel SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                if (Configuration.IsAdmin)
                {
                    _selectedItem = value;
                    if (_selectedItem != null)
                    {
                        _updatedItemsIds.Add(_selectedItem.Id);
                    }
                    OnPropertyChanged(nameof(SelectedItem));
                }
                else
                {
                    _selectedItem = value;
                    OnPropertyChanged(nameof(SelectedItem));
                }
            }
        }

        public ObservableCollection<TModel> Items
        {
            get
            {
                return _items;
            }
            set
            {
                _items = value;
                OnPropertyChanged(nameof(Items));
            }
        }

        #region Фильтр
        public string Filter
        {
            get => _filter;
            set
            {
                _filter = value;
                FilterAction(value);
                OnPropertyChanged(nameof(Filter));
            }
        }

        protected virtual void FilterAction(string value) { }
        #endregion

        #region Операции с данными

        #region Команды
        public Command AddNewRecord { get; }
        public Command DeleteSelectedItem { get; }
        public Command CommitChanges { get; set; }

        #endregion

        #region Методы

        private void Commit(object obj)
        {
            try
            {
                List<TModel> dbData;
                var itemsIds = Items.Select(x => x.Id);

                // deleting removed items
                using (var dbContext = _stocksDbContextFactory.CreateDbContext())
                {
                    dbContext.Set<TModel>().RemoveRange(dbContext.Set<TModel>().Where(x => !itemsIds.Contains(x.Id)));
                    dbData = dbContext.Set<TModel>().ToList();
                    dbContext.SaveChanges();
                }

                // add and update items
                using (var dbContext = _stocksDbContextFactory.CreateDbContext())
                {
                    foreach (var item in Items)
                    {
                        // add item if it is not exists in DB
                        if (!dbData.Any(x => x.Id == item.Id))
                        {
                            //item.Id = 0;
                            dbContext.Set<TModel>().Add(item);
                        }
                    }

                    // update selected items
                    dbContext.UpdateRange(Items.Where(x => _updatedItemsIds.Contains(x.Id)));
                    _updatedItemsIds.Clear();

                    dbContext.SaveChanges();

                    /*//Configuration.Issuers = new ObservableCollection<Issuer>(dbContext.Issuer);
                    Configuration.Dividends = new ObservableCollection<Dividend>(dbContext.Dividend);
                    Configuration.Market = new ObservableCollection<Stock>(dbContext.Stock);
                    //Configuration.MarketsStocks = new ObservableCollection<MarketStock>(dbContext.MarketStock);
                    Configuration.Markets = new ObservableCollection<Market>(dbContext.Market);
                    Configuration.CostByDates = new ObservableCollection<CostByDate>(dbContext.CostByDate);*/
                }
                MessageBox.Show("Successfully!");
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void AddRecord(object obj)
        {
            if (Items.Count != 0)
            {
                Items.Add(new TModel() { Id = MaxId() + 1 });
            }
            else
            {
                Items.Add(new TModel() { Id = 1 });
            }
        }

        private int MaxId()
        {
            int max = Items[0].Id;
            foreach (var item in Items)
            {
                if (item.Id > max)
                {
                    max = item.Id;
                }
            }
            return max;
        }

        private void DeleteItem(object obj)
        {
            if (new DialogWindow().ShowDialog() == true)
            {
                if (Items.Count != 0 && SelectedItem != null)
                {
                    var previousItemIndex = Items.IndexOf(SelectedItem) - 1;
                    if (previousItemIndex >= 0 && previousItemIndex < Items.Count)
                    {
                        var beforeSelectedItem = Items[previousItemIndex];
                        Items.Remove(SelectedItem);
                        SelectedItem = beforeSelectedItem;
                    }
                    else
                    {
                        Items.Remove(SelectedItem);
                    }
                }
            }            
        }

        #endregion


        #endregion

        //конструктор
        public TableViewModelFoundation()
        {
            _stocksDbContextFactory = new StocksDbContextFactory();
            _updatedItemsIds = new List<int>();
            DeleteSelectedItem = new RelayCommand(DeleteItem, (obj)=>Configuration.IsAdmin && String.IsNullOrEmpty(_filter));
            AddNewRecord = new RelayCommand(AddRecord, (obj) => Configuration.IsAdmin && String.IsNullOrEmpty(_filter));
            CommitChanges = new RelayCommand(Commit, (obj) => Configuration.IsAdmin && String.IsNullOrEmpty(_filter));
        }
    }
}
