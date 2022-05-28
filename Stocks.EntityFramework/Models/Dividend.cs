

using Stocks.EntityFramework.Models.Base;

namespace Stocks.EntityFramework.Models
{
    public class Dividend : BaseEntity
    {
        public DateOnly DivTime { get; set; }
        public double DivAmount { get; set; }
        public double DivProfit { get; set; }
        public Stock Stock { get; set; }
    }
}
