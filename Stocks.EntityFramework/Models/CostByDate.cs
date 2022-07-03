using Stocks.EntityFramework.Models.Base;

namespace Stocks.EntityFramework.Models
{
    public class CostByDate : BaseEntity
    {
        public DateTime TradeDate { get; set; }
        //public double? LegalClosePrice { get; set; }
        public double Close { get; set; }
        public string StockSecID { get; set; }
        public Stock Stock { get; set; }
    }
}
