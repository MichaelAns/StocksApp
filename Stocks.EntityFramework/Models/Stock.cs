using Stocks.EntityFramework.Models.Base;

namespace Stocks.EntityFramework.Models
{
    internal class Stock : BaseEntity
    {
        public string StockName { get; set; }
        public Issuer Issuer { get; set; }
        public virtual ICollection<Dividend>? Dividends { get; set; } 
        public virtual ICollection<MarketStock>? MarketsStocks { get; set; }
    }
}
