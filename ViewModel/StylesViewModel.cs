using BeerMaster.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerMaster.ViewModel
{
    public class StylesViewModel : ViewModelBase
    {
        private MainWindowViewModel _mvm;

        public StylesViewModel(MainWindowViewModel mvm) 
        {
            _mvm = mvm;
        }
    }
}
