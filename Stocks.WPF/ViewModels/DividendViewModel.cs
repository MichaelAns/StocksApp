using Stocks.EntityFramework.Models;
using Stocks.API.Services;
using System.Windows.Input;

namespace Stocks.WPF.ViewModels
{
    internal class DividendViewModel : Base.TableViewModelFoundation<Dividend>
    {

        //конструктор
        public DividendViewModel(Stock stock)
        {
            LoadDividend(stock);
        }        

        //загрузка данных
        private void LoadDividend(Stock stock)
        {
            new DividendApiService(stock.SecID).Get().ContinueWith(task =>
            {
                if (task.Exception == null)
                {
                    _allItems = task.Result;
                    Items = _allItems;
                }
            });
        }

        public ICommand BackCommand => OpenViewModel.MainNavigator.UpdateCurrentViewModelCommand;        
    }
}
