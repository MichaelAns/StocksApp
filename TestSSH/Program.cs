using TestSSH.DatabaseContext;

internal class Program
{
    private static void Main(string[] args)
    {
        // здесь должен быть SSH Client
        using (var dbContext = new TestDbContextFactory().CreateDbContext())
        {

        }
    }
}