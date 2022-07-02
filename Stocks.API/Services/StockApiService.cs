using Newtonsoft.Json.Linq;
using Stocks.API.Models;
using Stocks.API.Services.Base;
using Stocks.EntityFramework.Models;
using System.Collections.ObjectModel;

namespace Stocks.API.Services
{
    public class StockApiService : IApiService<Stock>
    {
        private readonly string _uri = @"https://iss.moex.com/iss/engines/stock/markets/shares/securities.json?iss.meta=off&securities.columns=SECID,SECNAME,CURRENCYID&iss.version=off&iss.only=securities&iss.json=extended";
        public async Task<ObservableCollection<Stock>> Get()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(_uri);
                string jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonToStocks(jsonResponse);
            }
        }

        private ObservableCollection<Stock> JsonToStocks(string jsonResponse)
        {
            try
            {
                JContainer jContainer = (JContainer)JContainer.Parse(jsonResponse);
                JObject jObj = JObject.FromObject(jContainer.Last);
                JToken jToken = jObj["securities"];
                return SecuritieToStock(jToken.ToObject<List<Securitie>>());
            }
            catch (NullReferenceException)
            {
                return null;
            }

        }
        private ObservableCollection<Stock> SecuritieToStock(List<Securitie> securities)
        {
            ObservableCollection<Stock> stocks = new ObservableCollection<Stock>();
            foreach (var securitie in securities)
            {
                stocks.Add(new Stock()
                {
                    Id = 0,
                    CurrencyID = securitie.CURRENCYID,
                    SecID = securitie.SECID,
                    SecName = securitie.SECNAME,
                    MarketID = 1
                });
            }
            return stocks;
        }
    }
}
