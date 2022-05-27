using Stocks.WPF.Infrastructures.Commands.Base;
using Stocks.WPF.Infrastructures.Enums;
using Stocks.WPF.Infrastructures.Navigators;
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
                    /*case ViewType.Home:
                        _navigator.CurrentViewModel = new HomeViewModel();
                        break;
                    case ViewType.Portfolio:
                        _navigator.CurrentViewModel = new PortfolioViewModel();
                        break;
                    default:
                        break;*/
                }
            }
        }
    }
}
