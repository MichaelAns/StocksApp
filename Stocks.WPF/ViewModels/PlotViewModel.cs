using System.Windows.Input;

namespace Stocks.WPF.ViewModels
{
    internal class PlotViewModel : ViewModels.Base.ViewModel
    {
        public ICommand BackCommand => OpenViewModel.MainNavigator.UpdateCurrentViewModelCommand;
        
    }
}
