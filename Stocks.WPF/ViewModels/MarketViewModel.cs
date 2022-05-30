using Stocks.EntityFramework.Models;
using Stocks.WPF.Infrastructures;

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
    }
}
