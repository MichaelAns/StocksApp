using Stocks.EntityFramework.Models;
using Stocks.WPF.Infrastructures;

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
    }
}
