using Stocks.EntityFramework.Models.Base;

namespace Stocks.EntityFramework.Models
{
    public class Market : BaseEntity
    {
        public string MarketName { get; set; }
        public string MarketCoutry { get; set; }
        //public ICollection<MarketStock>? MarketsStocks { get; set; }
        
    }
}
