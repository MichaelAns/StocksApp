using Stocks.EntityFramework.Models;
using Stocks.WPF.Infrastructures;

namespace Stocks.WPF.ViewModels
{
    internal class MarketStockViewModel : Base.TableViewModelFoundation<MarketStock>
    {
        public MarketStockViewModel()
        {
            using (var dbContext = _stocksDbContextFactory.CreateDbContext())
            {
                Items = Configuration.MarketsStocks;
            }
        }
    }
}
