using Stocks.EntityFramework.Models;
using Stocks.WPF.Infrastructures;
using System.Collections.ObjectModel;

namespace Stocks.WPF.ViewModels
{
    internal class StockViewModel : ViewModels.Base.TableViewModelFoundation<Stock>
    {
        public StockViewModel()
        {
            using (var dbContext = _stocksDbContextFactory.CreateDbContext())
            {
                Items = Configuration.Stocks;
            }
        }
        public override string Filter
        {
            get => _filter;
            set
            {
                _filter = value;
                if (string.IsNullOrEmpty(_filter))
                {
                    Items = Configuration.Stocks;
                }
                else
                {
                    Items = new ObservableCollection<Stock>();
                    foreach (var stock in Configuration.Stocks)
                    {
                        if (stock.Id.ToString().Contains(value) ||
                            stock.IssuerId.ToString().Contains(value) ||
                            stock.StockName.Contains(value))
                        {
                            Items.Add(stock);
                        }
                    }
                }
                OnPropertyChanged(nameof(Filter));
            }
        }
    }
}
