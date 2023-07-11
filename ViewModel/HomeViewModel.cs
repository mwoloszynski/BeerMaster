using BeerMaster.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerMaster.ViewModel
{
    public class HomeViewModel : ViewModelBase
    {
        private MainWindowViewModel _mvm;

        public HomeViewModel(MainWindowViewModel mvm)
        {
            _mvm = mvm;
        }
    }
}
