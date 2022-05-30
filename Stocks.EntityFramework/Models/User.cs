namespace Stocks.EntityFramework.Models
{
    public class User : Base.BaseEntity
    {
        public string UserLogin { get; set; }
        public string UserPassword { get; set; }
        public bool UserIsAdmin { get; set; }
    }
}
