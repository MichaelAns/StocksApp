using Stocks.EntityFramework.Models;
using Stocks.WPF.Infrastructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocks.WPF.ViewModels
{
    internal class DividendViewModel : Base.TableViewModelFoundation<Dividend>
    {
        public DividendViewModel()
        {
            using (var dbContext = _stocksDbContextFactory.CreateDbContext())
            {
                Items = Configuration.Dividends;
            }
        }
    }
}
