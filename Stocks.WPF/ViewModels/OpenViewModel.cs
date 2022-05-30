using Stocks.WPF.Infrastructures.Navigators;
using Stocks.WPF.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocks.WPF.ViewModels
{
    internal class OpenViewModel : ViewModel
    {
        public static INavigator MainNavigator { get; set; } = new Navigator(new LoginViewModel());
    }
}
