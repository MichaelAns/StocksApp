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
        protected override void FilterAction(string value)
        {
            if (string.IsNullOrEmpty(_filter))
            {
                Items = Configuration.Issuers;
            }
            else
            {
                Items = new ObservableCollection<Issuer>();
                foreach (var issuer in Configuration.Issuers)
                {
                    if (issuer.Id.ToString().ToLower().Contains(value.ToLower()) ||
                        issuer.IssuerCost.ToString().ToLower().Contains(value.ToLower()) ||
                            issuer.IssuerCountry.ToLower().Contains(value.ToLower()) ||
                            issuer.IssuerName.ToLower().Contains(value.ToLower()) ||
                            issuer.IssuerProfit.ToString().ToLower().Contains(value.ToLower()))
                    {
                        Items.Add(issuer);
                    }
                }
            }
        }
    }
}
