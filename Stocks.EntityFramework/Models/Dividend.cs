

using Stocks.EntityFramework.Models.Base;

namespace Stocks.EntityFramework.Models
{
    public class Dividend : BaseEntity
    {
        public DateTimeOffset DivTime { get; set; }
        public double DivAmount { get; set; }
        public double DivProfit { get; set; }
        public int StockId { get; set; }
        public Stock Stock { get; set; }
    }
}
