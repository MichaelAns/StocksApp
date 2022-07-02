using Stocks.API.Services;
using Stocks.EntityFramework.Models;
using System.Collections.ObjectModel;

ObservableCollection<Stock> stocks = await ApiService.GetStocks();
Console.Read();

