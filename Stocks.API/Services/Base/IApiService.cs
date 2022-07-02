using System.Collections.ObjectModel;

namespace Stocks.API.Services.Base
{
    public interface IApiService<Model>
    {
        public Task<ObservableCollection<Model>> Get();
    }
}
