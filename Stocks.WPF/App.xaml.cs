using Stocks.API.Services;
using Stocks.EntityFramework.Date;
using Stocks.EntityFramework.Models;
using Stocks.WPF.Infrastructures;
using Stocks.WPF.ViewModels;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;

namespace Stocks.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override async void OnStartup(StartupEventArgs e)
        {
            //Configuration.Market = await new StockApiService().Get();
            /*using (var dbContext = new StocksDbContextFactory().CreateDbContext())
            {
                *//*Configuration.Issuers = new ObservableCollection<Issuer>(dbContext.Issuer);
                Configuration.Dividends = new ObservableCollection<Dividend>(dbContext.Dividend);
                Configuration.Market = new ObservableCollection<Stock>(dbContext.Stock);
                Configuration.MarketsStocks = new ObservableCollection<MarketStock>(dbContext.MarketStock);
                Configuration.Markets = new ObservableCollection<Market>(dbContext.Market);
                Configuration.CostByDates = new ObservableCollection<CostByDate>(dbContext.CostByDate);*//*
            }*/
            Window window = new MainWindow();
            window.DataContext = new OpenViewModel();
            window.Show();
            base.OnStartup(e);
        }
        
    }
}
