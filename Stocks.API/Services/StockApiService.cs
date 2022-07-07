using Stocks.API.Models;
using Stocks.API.Services.Base;
using Stocks.EntityFramework.Models;

namespace Stocks.API.Services
{
    public class StockApiService : ApiService<Stock, Securitie>
    {
        public StockApiService()
        {
            _uri = @"https://iss.moex.com/iss/engines/stock/markets/shares/securities.json?iss.meta=off&securities.columns=SECID,SECNAME,CURRENCYID&iss.version=off&iss.only=securities&iss.json=extended";
            _blockName = "securities";
        }

        protected override void Add(Securitie apiModel)
        {
            _models.Add(new Stock()
            {
                Id = 0,
                CurrencyID = apiModel.CURRENCYID,
                SecID = apiModel.SECID,
                SecName = apiModel.SECNAME,
                MarketID = 1
            });
        }
    }
}
