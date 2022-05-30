using Stocks.WPF.Infrastructures.Commands;
using Stocks.WPF.Infrastructures.Commands.Base;
using Stocks.WPF.Infrastructures.Navigators;
using System.Windows.Input;

namespace Stocks.WPF.ViewModels
{
    internal class LoginViewModel : ViewModels.Base.ViewModel
    {
        //public ICommand UpdateCurrentViewModelCommand => new UpdateCurrentViewModelCommand();
        public ICommand OnButtonClick => OpenViewModel.MainNavigator.UpdateCurrentViewModelCommand;
    }
}
