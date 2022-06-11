using Stocks.EntityFramework.Models;
using Stocks.WPF.Infrastructures;

namespace Stocks.WPF.ViewModels
{
    internal class CostByDateViewModel : Base.TableViewModelFoundation<CostByDate>
    {
        public CostByDateViewModel()
        {
            Items = Configuration.CostByDates;
        }
    }
}
