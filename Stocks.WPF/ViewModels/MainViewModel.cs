using Stocks.WPF.Infrastructures.Navigators;
using Stocks.WPF.ViewModels.Base;

namespace Stocks.WPF.ViewModels
{
    internal class MainViewModel : ViewModel
    {
        public INavigator Navigator { get; set; } = new Navigator();
    }
}
