using System.Collections.ObjectModel;

namespace Stocks.API.Services.Base
{
    public interface IApiService<T>
    {
        public Task<ObservableCollection<T>> Get();
    }
}
