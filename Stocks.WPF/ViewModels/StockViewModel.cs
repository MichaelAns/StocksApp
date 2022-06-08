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
                Items = Configuration.Market;
            }
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
