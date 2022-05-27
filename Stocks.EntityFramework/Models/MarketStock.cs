using Stocks.EntityFramework.Models.Base;

namespace Stocks.EntityFramework.Models
{
    internal class MarketStock : BaseEntity
    {
        public Stock Stock { get; set; }
        public Market Market { get; set; }  
        public string MsCurrency { get; set; }
        public ICollection<CostByDate>? CostsByDates { get; set; }
    }
}
