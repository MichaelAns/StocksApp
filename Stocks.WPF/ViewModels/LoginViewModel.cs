﻿using Microsoft.EntityFrameworkCore;
using Stocks.EntityFramework.Date;
using Stocks.EntityFramework.Models;
using Stocks.EntityFramework.Services;
using Stocks.WPF.Infrastructures;
using Stocks.WPF.Infrastructures.Commands;
using Stocks.WPF.Infrastructures.Commands.Base;
using Stocks.WPF.Infrastructures.Navigators;
using System.Windows;
using System.Windows.Input;

namespace Stocks.WPF.ViewModels
{
    internal class LoginViewModel : ViewModels.Base.ViewModel
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
        #region Login
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
        private async void LogInAsync(object obj)
        {
            try
            {
                User user;
                //действия
                using (var dbContext = new StocksDbContextFactory().CreateDbContext())
                {
                    user = await dbContext.Set<User>().FirstOrDefaultAsync((e) => e.UserLogin == _login && e.UserPassword == _password);
                }
                Configuration.IsAdmin = user.UserIsAdmin;
                OpenViewModel.MainNavigator.CurrentViewModel = new MainViewModel();
            }
            catch
            {
                MessageBox.Show("Неправильно введен логин/пароль или пользователя не существует");
            } 
        }
        public ICommand OnLoginClick { get; }

        #endregion

        #region SignIn
        public ICommand OnSignInClick => OpenViewModel.MainNavigator.UpdateCurrentViewModelCommand;
        #endregion

        public LoginViewModel()
        {
            OnLoginClick = new RelayCommand(LogInAsync, CanLogin);
        }

    }
}
