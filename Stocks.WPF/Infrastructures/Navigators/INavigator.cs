using Stocks.WPF.Infrastructures.Commands.Base;
using Stocks.WPF.ViewModels.Base;
using System.Windows.Input;

namespace Stocks.WPF.Infrastructures.Navigators
{
    internal interface INavigator
    {
        ViewModel CurrentViewModel { get; set; }
        ICommand UpdateCurrentViewModelCommand { get; }
    }
}
