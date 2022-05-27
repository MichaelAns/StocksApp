using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Stocks.EntityFramework.Date
{
    internal class StocksDbContextFactory : IDesignTimeDbContextFactory<StocksDbContext>
    {
        public StocksDbContext CreateDbContext(string[] args)
        {
            var options = new DbContextOptionsBuilder<StocksDbContext>();
            options.UseNpgsql("Host=localhost;Port=5432;Database=SimpleTraderDB;Username=postgres;Password=postgres");
            return new StocksDbContext(options.Options);
        }
    }
}
