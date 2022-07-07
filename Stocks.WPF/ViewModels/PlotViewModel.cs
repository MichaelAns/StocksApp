using Stocks.API.Services;
using Stocks.EntityFramework.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Stocks.WPF.ViewModels
{
    internal class PlotViewModel : ViewModels.Base.ViewModel
    {
        private readonly Stock _stock; 
        private string _title;
        //private ObservableCollection<CostByDate> _costByDate;
        private ObservableCollection<CostByDate> _costDate = new();

        //констркутор
        public PlotViewModel(Stock stock)
        {
            _stock = stock;
            Title = stock.CurrencyID;  
        }

        #region Методы
        //фабрика модели представления
        public static PlotViewModel LoadPlotViewModel(Stock stock)
        {
            PlotViewModel plot = new PlotViewModel(stock);
            plot.LoadCostByDate();
            return plot;
        }

        private void LoadCostByDate()
        {
            new CostByDateApiService(_stock.SecID).Get().ContinueWith(task =>
            {
                if (task.Exception == null)
                {
                    CostDate = task.Result;
                }
            });
        }

        #endregion

        //свойства
        public ObservableCollection<CostByDate> CostDate { get => _costDate; set => Set(ref _costDate, value); }
        public string Title { get => _title; set => Set(ref _title, value); }


        //команды
        public ICommand BackCommand => OpenViewModel.MainNavigator.UpdateCurrentViewModelCommand;

    }
}
