using Stocks.EntityFramework.Models;
using Stocks.WPF.Infrastructures;
using System.Collections.ObjectModel;

namespace Stocks.WPF.ViewModels
{
    internal class StockViewModel : ViewModels.Base.TableViewModelFoundation<Stock>
    {
        public StockViewModel()
        {
            using (var dbContext = _stocksDbContextFactory.CreateDbContext())
            {
                Items = Configuration.Stocks;
            }
        }
        protected override void FilterAction(string value)
        {
            if (string.IsNullOrEmpty(_filter))
            {
                Items = Configuration.Stocks;
            }
            else
            {
                Items = new ObservableCollection<Stock>();
                foreach (var stock in Configuration.Stocks)
                {
                    if (stock.Id.ToString().ToLower().Contains(value.ToLower()) ||
                        stock.IssuerId.ToString().ToLower().Contains(value.ToLower()) ||
                        stock.StockName.ToLower().Contains(value.ToLower()))
                    {
                        Items.Add(stock);
                    }
                }
            }
        }
    }
}
