using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Stocks.EntityFramework.Date
{
    public class StocksDbContextFactory : IDesignTimeDbContextFactory<StocksDbContext>
    {
        public StocksDbContext CreateDbContext(string[] args = null)
        {
            var options = new DbContextOptionsBuilder<StocksDbContext>();
            options.UseNpgsql("Host=localhost;Port=5432;Database=StocksDbWithAPI;Username=postgres;Password=postgres");
            return new StocksDbContext(options.Options);
        }
    }
}
