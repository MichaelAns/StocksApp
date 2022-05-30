using Stocks.EntityFramework.Date;
using Stocks.EntityFramework.Models;
using Stocks.WPF.Infrastructures;
using Stocks.WPF.ViewModels.Base;
using System.Collections.ObjectModel;

namespace Stocks.WPF.ViewModels
{
    internal class IssuerViewModel : TableViewModelFoundation<Issuer>
    {
        public IssuerViewModel()
        {
            using(var dbContext = _stocksDbContextFactory.CreateDbContext())
            {
                Items = Configuration.Issuers;
            }
        }
    }
}
