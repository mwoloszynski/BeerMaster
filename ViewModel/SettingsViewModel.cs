using BeerMaster.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerMaster.ViewModel
{
    public class SettingsViewModel : ViewModelBase
    {
        private MainWindowViewModel _mvm;

        public SettingsViewModel(MainWindowViewModel mvm)
        {
            _mvm = mvm;
        }
    }
}
