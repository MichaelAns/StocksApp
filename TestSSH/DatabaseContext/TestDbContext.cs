using Microsoft.EntityFrameworkCore;
using TestSSH.Models;

namespace TestSSH.DatabaseContext
{
    public class TestDbContext : DbContext
    {
        public TestDbContext(DbContextOptions options) : base(options)
        {
            Database.Migrate();
        }
        DbSet<TestModel> TestModel { get; set; }
    }
}
