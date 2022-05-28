using Microsoft.EntityFrameworkCore;
using Stocks.EntityFramework.Models;

namespace Stocks.EntityFramework.Date
{
    public class StocksDbContext : DbContext
    {
        public StocksDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Stock> Stock { get; set; }
        public DbSet<Dividend> Dividend { get; set; }
        public DbSet<MarketStock> MarketStock { get; set; }
        public DbSet<Market> Market { get; set; }
        public DbSet<Issuer> Issuer { get; set; }
        public DbSet<CostByDate> CostByDate { get; set; }
    }
}
