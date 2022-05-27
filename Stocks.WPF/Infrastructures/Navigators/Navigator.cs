using Stocks.WPF.ViewModels.Base;
using System.ComponentModel;
using System.Windows.Input;

namespace Stocks.WPF.Infrastructures.Navigators
{
    internal class Navigator : INavigator, INotifyPropertyChanged
    {
        private ViewModel _currentViewModel;
        public ViewModel CurrentViewModel
        {
            get
            {
                return _currentViewModel;
            }
            set
            {
                _currentViewModel = value;
                OnPropertyChanged(nameof(CurrentViewModel));
            }
        }

        public ICommand UpdateCurrentViewModelCommand => new UpdateCurrentViewModelCommand(this);

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
