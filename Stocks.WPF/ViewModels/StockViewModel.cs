using Stocks.API.Services;
using Stocks.EntityFramework.Models;
using Stocks.WPF.Infrastructures;
using Stocks.WPF.Infrastructures.Commands;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Stocks.WPF.ViewModels
{
    internal class StockViewModel : ViewModels.Base.TableViewModelFoundation<Stock>
    {
        private static StockViewModel _stockViewModel;
        private StockViewModel()
        {
            MakePlotCommand = new RelayCommand(MakePlotExecute, MakePlotCanExecute);
            LookDividendsCommand = new RelayCommand(LookDividendsExecute, LookDividendsCanExecute);
        }

        //фабрика
        public static StockViewModel LoadStockViewModel()
        {
            if (_stockViewModel == null)
            {
                _stockViewModel = new();
                _stockViewModel.LoadStock();
            }
            return _stockViewModel;
        }

        //загрузка данных
        private void LoadStock()
        {
            new StockApiService().Get().ContinueWith(task =>
            {
                if (task.Exception == null)
                {
                    _allItems = task.Result;
                    Items = _allItems;
                }
            });
        }

        //фильтр
        protected override void FilterAction(string value)
        {
            if (string.IsNullOrEmpty(_filter))
            {
                Items = _allItems;
            }
            else
            {
                Items = new ObservableCollection<Stock>();
                foreach (var stock in _allItems)
                {
                    if (stock.Id.ToString().ToLower().Contains(value.ToLower()) ||
                        stock.SecID.ToLower().Contains(value.ToLower()) ||
                        stock.CurrencyID.ToLower().Contains(value.ToLower()) ||
                        stock.SecName.ToLower().Contains(value.ToLower()))
                    {
                        Items.Add(stock);
                    }
                }
            }
        }

        #region Создание графика

        //свойство
        public ICommand MakePlotCommand { get;}

        //метод
        private void MakePlotExecute(object obj)
        {
            OpenViewModel.MainNavigator.CurrentViewModel = PlotViewModel.LoadPlotViewModel((SelectedItem));
        }

        //можно ли
        private bool MakePlotCanExecute(object obj)
        {
            if (SelectedItem!=null)
            {
                return true;
            }
            return false;
        }

        #endregion

        #region Просмотр дивидендов

        //свойство
        public ICommand LookDividendsCommand { get; }

        //execute
        private void LookDividendsExecute(object obj)
        {
            OpenViewModel.MainNavigator.CurrentViewModel = new DividendViewModel(SelectedItem);
        }

        //can execute
        private bool LookDividendsCanExecute(object obj)
        {
            if (SelectedItem != null)
            {
                return true;
            }
            return false;
        }

        #endregion



    }
}
