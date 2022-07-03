using Stocks.API.Services;
using Stocks.EntityFramework.Models;
using System.Collections.ObjectModel;

//ObservableCollection<Stock> stocks = await ApiService.GetStocks();
//StockApiService stockApiService = new StockApiService();
//var stocks = await stockApiService.Get();
//Console.WriteLine(stocks[0].SecID);

var costByDateApiService = new CostByDateApiService("KMAZ");

new CostByDateApiService("KMAZ").Get().ContinueWith((task) =>
{
    var CostByDate = task.Result;
});
Console.Read();

