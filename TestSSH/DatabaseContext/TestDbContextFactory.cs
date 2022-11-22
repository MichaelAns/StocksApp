using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace TestSSH.DatabaseContext
{
    public class TestDbContextFactory : IDesignTimeDbContextFactory<TestDbContext>
    {
        public TestDbContext CreateDbContext(string[] args = null)
        {
            var options = new DbContextOptionsBuilder<TestDbContext>();
            options.UseNpgsql("Host=localhost; Port=5432; Database=Test;Username=postgres;Password=postgres");
            return new TestDbContext(options.Options);
        }
    }
}
