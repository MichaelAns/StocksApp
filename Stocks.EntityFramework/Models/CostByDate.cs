using Stocks.EntityFramework.Models.Base;

namespace Stocks.EntityFramework.Models
{
    public class CostByDate : BaseEntity
    {
        public DateTimeOffset CbdDate { get; set; }
        public double CbdPrice { get; set; }
        public int MarketStockId { get; set; }
        public MarketStock MarketStock { get; set; }
    }
}
