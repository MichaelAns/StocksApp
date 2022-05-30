using Stocks.WPF.Infrastructures.Commands;
using System.Windows.Input;

namespace Stocks.WPF.ViewModels
{
    internal class RegistrationViewModel : ViewModels.Base.ViewModel
    {
        private string _login;
        private string _password;     
        public string Login
        {
            get => _login;
            set => Set(ref _login, value);
        }
        public string Password
        {
            get => _password;
            set => Set(ref _password, value);
        }
        #region SignIn

        public ICommand OnSignInClick { get; }
        //проверка на поля
        private bool CanLogin(object obj)
        {
            if (string.IsNullOrEmpty(_login) || string.IsNullOrEmpty(_password))
            {
                return false;
            }
            return true;
        }

        //сам вход
        private void SignIn(object obj)
        {
            try
            {
                //действия

                OpenViewModel.MainNavigator.CurrentViewModel = new LoginViewModel();
            }
            catch
            {

            }
        }
        #endregion

        #region Back
        public ICommand OnBackClick => OpenViewModel.MainNavigator.UpdateCurrentViewModelCommand;
        #endregion

        public RegistrationViewModel()
        {
            OnSignInClick = new RelayCommand(SignIn, CanLogin);
        }
        //public ICommand OnButtonClick => OpenViewModel.MainNavigator.UpdateCurrentViewModelCommand;
    }
}
