using System.Windows.Input;

namespace Stocks.WPF.ViewModels
{
    internal class RegistrationViewModel : ViewModels.Base.ViewModel
    {
        public ICommand OnButtonClick => OpenViewModel.MainNavigator.UpdateCurrentViewModelCommand;
    }
}
