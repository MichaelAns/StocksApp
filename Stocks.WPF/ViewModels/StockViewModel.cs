using Stocks.EntityFramework.Models;
using Stocks.WPF.Infrastructures;
using Stocks.WPF.Infrastructures.Commands;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Stocks.WPF.ViewModels
{
    internal class StockViewModel : ViewModels.Base.TableViewModelFoundation<Stock>
    {
        public StockViewModel()
        {
            Items = Configuration.Market;
            MakePlotCommand = new RelayCommand(MakePlotExecute, MakePlotCanExecute);
            LookDividendsCommand = new RelayCommand(LookDividendsExecute, obj => true);
        }
        protected override void FilterAction(string value)
        {
            if (string.IsNullOrEmpty(_filter))
            {
                Items = Configuration.Market;
            }
            else
            {
                Items = new ObservableCollection<Stock>();
                foreach (var stock in Configuration.Market)
                {
                    if (stock.Id.ToString().ToLower().Contains(value.ToLower()) ||
                        stock.SecID.ToLower().Contains(value.ToLower()))
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
            //OpenViewModel.MainNavigator.CurrentViewModel = new PlotViewModel(SelectedItem.Id);
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
