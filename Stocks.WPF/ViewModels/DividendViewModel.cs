using Stocks.EntityFramework.Models;
using Stocks.WPF.Infrastructures;
using System.Windows.Input;

namespace Stocks.WPF.ViewModels
{
    internal class DividendViewModel : Base.TableViewModelFoundation<Dividend>
    {
        public DividendViewModel()
        {
        }

        public DividendViewModel(Stock selectedItem)
        {
            using (var dbContext = _stocksDbContextFactory.CreateDbContext())
            {
                Items = Configuration.Dividends;
            }
        }

        public ICommand BackCommand => OpenViewModel.MainNavigator.UpdateCurrentViewModelCommand;
    }
}
