using Stocks.EntityFramework.Models.Base;

namespace Stocks.EntityFramework.Models
{
    public class Stock : BaseEntity
    {        
        public string SecID { get; set; }
        public string SecName { get; set; }
        public string CurrencyID { get; set; }
        public int MarketID { get; set; }
        public virtual Market Market { get; set; }
        public virtual ICollection<Dividend>? Dividends { get; set; }
        public virtual ICollection<CostByDate>? CostByDates { get; set; }
        
    }
}
