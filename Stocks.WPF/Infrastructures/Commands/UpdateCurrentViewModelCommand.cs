using Stocks.WPF.Infrastructures.Commands.Base;
using Stocks.WPF.Infrastructures.Enums;
using Stocks.WPF.Infrastructures.Navigators;
using Stocks.WPF.ViewModels;
using System;

namespace Stocks.WPF.Infrastructures.Commands
{
    internal class UpdateCurrentViewModelCommand : Command
    {
        public event EventHandler? CanExecuteChanged;

        private INavigator _navigator;

        public UpdateCurrentViewModelCommand(INavigator navigator)
        {
            _navigator = navigator;
        }

        public override bool CanExecute(object? parameter)
        {
            return true;
        }

        public override void Execute(object? parameter)
        {
            if (parameter is ViewType)
            {
                ViewType viewType = (ViewType)parameter;
                switch (viewType)
                {
                    //таблицы
                    case ViewType.Issuer:
                        //_navigator.CurrentViewModel = new IssuerViewModel();
                        break;
                    case ViewType.Stock:
                        _navigator.CurrentViewModel = StockViewModel.LoadStockViewModel();
                        break;
                    case ViewType.Market:
                        _navigator.CurrentViewModel = new MarketViewModel();
                        break;
                    case ViewType.Dividend:
                        _navigator.CurrentViewModel = new DividendViewModel();
                        break;
                    case ViewType.CostByDate:
                        _navigator.CurrentViewModel = new CostByDateViewModel();
                        break;

                    //все остальное
                    case ViewType.Registration:
                        _navigator.CurrentViewModel = new RegistrationViewModel();
                        break;
                    case ViewType.Login:
                        _navigator.CurrentViewModel = new LoginViewModel();
                        break;
                    /*case ViewType.Plot:
                        _navigator.CurrentViewModel = new PlotViewModel();
                        break;*/
                    default:
                        _navigator.CurrentViewModel = new MainViewModel();
                        break;
                }
            }   
            else
            {
                _navigator.CurrentViewModel = new MainViewModel();
            }
        }
    }
}
