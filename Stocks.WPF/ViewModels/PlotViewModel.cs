using Stocks.API.Services;
using Stocks.EntityFramework.Models;
using Stocks.WPF.Infrastructures;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
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
            plot.CostDate = Configuration.CostByDates;
            plot.LoadCostByDate();
            //plot.GetCostAndData();
            return plot;
        }

        private void LoadCostByDate()
        {
            new CostByDateApiService(_stock.SecID).Get().ContinueWith(task =>
            {
                if (task.Exception == null)
                {
                    CostDate = task.Result;
                    for (int i = 0; i < 10; i++) ;
                }
            });
        }

        /*private void GetCostAndData()
        {
            foreach (CostByDate costByDate in _costByDate)
            {
                try
                {
                    CostDate.Add(new CostAndDate() { Date = new DateTime(costByDate.TradeDate.Year, costByDate.TradeDate.Month, costByDate.TradeDate.Day), Price = costByDate.Close });
                }
                catch (System.Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }
            }
        }*/

        #endregion

        //свойства
        public ObservableCollection<CostByDate> CostDate { get => _costDate; set => Set(ref _costDate, value); }
        public string Title { get => _title; set => Set(ref _title, value); }


        //команды
        public ICommand BackCommand => OpenViewModel.MainNavigator.UpdateCurrentViewModelCommand;

    }
    internal struct CostAndDate
    {
        public double Price { get; set; }
        public DateTime Date { get; set; }
    }
}
