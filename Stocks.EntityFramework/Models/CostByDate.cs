using Stocks.EntityFramework.Models.Base;

namespace Stocks.EntityFramework.Models
{
    internal class CostByDate : BaseEntity
    {
        public DateOnly CbdDate { get; set; }
        public double CbdPrice { get; set; }
        public MarketStock MarketStock { get; set; }
    }
}
