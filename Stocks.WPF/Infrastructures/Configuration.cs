using Microsoft.EntityFrameworkCore;
using Stocks.EntityFramework.Date;
using Stocks.EntityFramework.Models;
using System.Collections.ObjectModel;

namespace Stocks.WPF.Infrastructures
{
    internal static class Configuration
    {
        public static bool IsAdmin { get; set; } = false;
        public static ObservableCollection<Market> Markets { get; set; }
        public static ObservableCollection<Dividend> Dividends { get; set; }
        public static ObservableCollection<Stock> Market { get; set; }
        public static ObservableCollection<CostByDate> CostByDates { get; set; }
    }
}
