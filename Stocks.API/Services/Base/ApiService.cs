using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Stocks.API.Services.Base
{
    public abstract class ApiService<Model, ApiModel> : IApiService<Model>
    {
        protected string _uri;
        protected string _blockName;
        protected ObservableCollection<Model> models;

        public async Task<ObservableCollection<Model>> Get()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(_uri);
                string jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonToStocks(jsonResponse);
            }
        }
        protected abstract void Add(ApiModel apiModel);

        private ObservableCollection<Model> JsonToStocks(string jsonResponse)
        {
            try
            {
                JContainer jContainer = (JContainer)JContainer.Parse(jsonResponse);
                JObject jObj = JObject.FromObject(jContainer.Last);
                JToken jToken = jObj[_blockName];
                return ApiModelToModel(jToken.ToObject<List<ApiModel>>());
            }
            catch (NullReferenceException)
            {
                return null;
            }
        }
        private ObservableCollection<Model> ApiModelToModel(List<ApiModel> apiModels)
        {
            models = new ObservableCollection<Model>();
            foreach (var apiModel in apiModels)
            {
                Add(apiModel);
            }
            return models;
        }

    }
}
