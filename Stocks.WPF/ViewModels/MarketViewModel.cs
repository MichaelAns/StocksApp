using Stocks.EntityFramework.Models;
using Stocks.WPF.Infrastructures;
using System.Collections.ObjectModel;

namespace Stocks.WPF.ViewModels
{
    internal class MarketViewModel : Base.TableViewModelFoundation<Market>
    {
        public MarketViewModel()
        {
            using (var dbContext = _stocksDbContextFactory.CreateDbContext())
            {
                Items = Configuration.Markets;
            }
        }
        protected override void FilterAction(string value)
        {
            if (string.IsNullOrEmpty(_filter))
            {
                Items = Configuration.Markets;
            }
            else
            {
                Items = new ObservableCollection<Market>();
                foreach (var market in Configuration.Markets)
                {
                    if (market.Id.ToString().ToLower().Contains(value.ToLower()) ||
                        market.MarketName.ToString().ToLower().Contains(value.ToLower()) ||
                        market.MarketCoutry.ToLower().Contains(value.ToLower()))
                    {
                        Items.Add(market);
                    }
                }
            }
        }
    }
}
