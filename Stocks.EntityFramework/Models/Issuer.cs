using Stocks.EntityFramework.Models.Base;

namespace Stocks.EntityFramework.Models
{
    public class Issuer : BaseEntity
    {
        public string IssuerName { get; set; }
        public double IssuerCost { get; set; }
        public double IssuerProfit { get; set; }
        public string IssuerCountry { get; set; }
        public ICollection<Stock> Stocks { get; set; }
    }
}
