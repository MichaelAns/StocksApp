using Stocks.API.Models;
using Stocks.EntityFramework.Models;

namespace Stocks.API.Services
{
    public class DividendApiService : Base.ApiService<Dividend, Div>
    {
        public DividendApiService(string secId)
        {
            _uri = @$"https://iss.moex.com/iss/securities/{secId}/dividends.json?iss.meta=off&iss.version=off&iss.json=extended";
            _blockName = "dividends";
        }

        protected override void Add(Div apiModel)
        {
            string[] date = apiModel.registryclosedate.Split('-'); //разбиение строки с датой на данные для типа данных дата
            _models.Add(new Dividend()
            {
                Id = 0,
                RegistryCloseDate = new DateTime(int.Parse(date[0]), int.Parse(date[1]), int.Parse(date[2])),
                StockSecID = apiModel.secid,
                Value = apiModel.value,
                CurrencyID = apiModel.currencyid,
                Isin = apiModel.isin
            }) ;
        }
    }
}
