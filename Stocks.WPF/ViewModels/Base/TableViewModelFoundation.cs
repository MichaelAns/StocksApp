﻿using Stocks.EntityFramework.Date;
using Stocks.EntityFramework.Models.Base;
using Stocks.WPF.Infrastructures.Commands;
using Stocks.WPF.Infrastructures.Commands.Base;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Stocks.WPF.ViewModels.Base
{
    internal class TableViewModelFoundation<TModel> : ViewModel
        where TModel : BaseEntity, new()
    {
        protected readonly StocksDbContextFactory _stocksDbContextFactory;

        private ObservableCollection<TModel> _items;
        private TModel _selectedItem;
        protected List<int> _updatedItemsIds;


        private bool _isPermitted = true;
        public bool IsPermitted
        {
            get
            {
                return _isPermitted;
            }
            set
            {
                _isPermitted = value;
                OnPropertyChanged(nameof(IsPermitted));
            }
        }


        public TModel SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                _selectedItem = value;
                if (_selectedItem != null)
                {
                    _updatedItemsIds.Add(_selectedItem.Id);
                }
                OnPropertyChanged(nameof(SelectedItem));
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



        #region Операции с данными

        #region Команды
        public Command AddNewRecord { get; }
        public Command DeleteSelectedItem { get; }
        public Command CommitChanges { get; set; }

        #endregion

        #region Методы

        private void Commit(object obj)
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
                        item.Id = 0;
                        dbContext.Set<TModel>().Add(item);
                    }
                }

                // update selected items
                dbContext.UpdateRange(Items.Where(x => _updatedItemsIds.Contains(x.Id)));
                _updatedItemsIds.Clear();

                dbContext.SaveChanges();
            }
        }

        private void AddRecord(object obj)
        {
            if (Items.Count != 0)
            {
                Items.Add(new TModel() { Id = Items[^1].Id + 1 });
            }
            else
            {
                Items.Add(new TModel() { Id = 1 });
            }
        }

        private void DeleteItem(object obj)
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

        #endregion


        #endregion

        //конструктор
        public TableViewModelFoundation(StocksDbContextFactory stocksDbContextFactory)
        {
            _stocksDbContextFactory = stocksDbContextFactory;
            _updatedItemsIds = new List<int>();
            DeleteSelectedItem = new RelayCommand(DeleteItem, (obj)=>true);
            AddNewRecord = new RelayCommand(AddRecord);
            CommitChanges = new RelayCommand(Commit);

            try
            {
                TModel buf = null;
                using (var dbContext = _stocksDbContextFactory.CreateDbContext())
                {

                    buf = dbContext.Add(new TModel()).Entity;
                    dbContext.SaveChanges();
                }
                IsPermitted = true;
                using (var dbContext = _stocksDbContextFactory.CreateDbContext())
                {
                    var b = dbContext.Remove(buf);
                    dbContext.SaveChanges();
                }
            }
            catch
            {
                IsPermitted = false;
            }
        }
    }
}