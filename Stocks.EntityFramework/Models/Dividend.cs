

using Stocks.EntityFramework.Models.Base;

namespace Stocks.EntityFramework.Models
{
    public class Dividend : BaseEntity
    {
        public DateTime RegistryCloseDate { get; set; }
        public double Value { get; set; }
        public string CurrencyID { get; set; }        
        public string StockSecID { get; set; }
        public Stock Stock { get; set; }
    }
}
