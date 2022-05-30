using Microsoft.EntityFrameworkCore;
using Stocks.EntityFramework.Date;
using Stocks.EntityFramework.Models;
using Stocks.WPF.Infrastructures.Commands;
using System.Threading.Tasks;
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

        //сама регистрация
        private async void SignInAsync(object obj)
        {
            try
            {
                User user;
                //действия
                using (var dbContext = new StocksDbContextFactory().CreateDbContext())
                {
                    user = await dbContext.Set<User>().FirstOrDefaultAsync((e) => e.UserLogin == _login && e.UserPassword == _password);
                }

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
            OnSignInClick = new RelayCommand(SignInAsync, CanLogin);
        }
        //public ICommand OnButtonClick => OpenViewModel.MainNavigator.UpdateCurrentViewModelCommand;
    }
}
