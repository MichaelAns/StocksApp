using Stocks.WPF.Infrastructures.Navigators;
using Stocks.WPF.ViewModels.Base;

namespace Stocks.WPF.ViewModels
{
    internal class OpenViewModel : ViewModel
    {
        public static INavigator MainNavigator { get; set; } = new Navigator(new LoginViewModel());
    }
}
