using Stocks.EntityFramework.Models;
using Stocks.WPF.Infrastructures;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Stocks.WPF.ViewModels
{
    internal class PlotViewModel : ViewModels.Base.ViewModel
    {
        //private int _stockID;
        private int _marketStockID;
        private string _title;
        private ObservableCollection<CostAndDate> _costData = new ObservableCollection<CostAndDate>();

        //констркутор
        public PlotViewModel(int stockID)
        {
            //_stockID = stockID;
            foreach (var marketStock in Configuration.MarketsStocks)
            {
                if (marketStock.StockId == stockID)
                {
                    _marketStockID = marketStock.Id;
                    _title = $"Cost ({marketStock.MsCurrency})";
                    break;
                }
            }
            foreach (var costByDate in Configuration.CostByDates)
            {
                if (costByDate.MarketStockId == _marketStockID)
                {
                    try
                    {
                        _costData.Add(new CostAndDate() { Date = costByDate.CbdDate.DateTime, Price = costByDate.CbdPrice });
                    }
                    catch (System.Exception exc)
                    {
                        MessageBox.Show(exc.Message);
                    }

                }
            }
        }

        //свойства
        public ObservableCollection<CostAndDate> CostData { get => _costData; set => Set(ref _costData, value); }
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
