using Stocks.API.Models;
using Stocks.API.Services.Base;
using Stocks.EntityFramework.Models;

namespace Stocks.API.Services
{
    public class CostByDateApiService : ApiService<CostByDate, CBD>
    {
        private string _stockSecID;
        public CostByDateApiService(string stockSecID)
        {
            _stockSecID = stockSecID;
            _uri = @$"https://iss.moex.com/iss/history/engines/stock/markets/shares/sessions/total/securities/{stockSecID}.json?from=2022-05-01&till=2022-11-08&iss.meta=off&history.columns=TRADEDATE,LEGALCLOSEPRICE,CLOSE&iss.version=off&iss.json=extended";
            _blockName = "history";
        }

        protected override void Add(CBD apiModel)
        {
            string[] date = apiModel.TRADEDATE.Split('-'); //разбиение строки с датой на данные для типа данных дата
            _models.Add(new CostByDate()
            {
                Id = 0,
                TradeDate = new DateTime(int.Parse(date[0]), int.Parse(date[1]), int.Parse(date[2])), //парсинг строки с датой на тип данных дата
                Close = apiModel.LEGALCLOSEPRICE is not null? (double)apiModel.LEGALCLOSEPRICE : (double)apiModel.CLOSE,
                StockSecID = _stockSecID
            });
        }
    }
}
