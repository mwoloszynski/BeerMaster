using BeerMaster.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerMaster.ViewModel
{
    public class RecipesViewModel : ViewModelBase
    {
        private MainWindowViewModel _mvm;

        public RecipesViewModel(MainWindowViewModel mvm)
        {
            _mvm = mvm;
        }
    }
}
