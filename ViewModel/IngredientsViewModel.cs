using BeerMaster.Model;
using BeerMaster.ViewModel.IngredientsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BeerMaster.ViewModel
{
    public class IngredientsViewModel : ViewModelBase
    {
        private MainWindowViewModel _mvm;
        private ViewModelBase _currentIngredientsViewModel;
        private MaltsViewModel _maltsViewModel;
        private HopsViewModel _hopsViewModel;
        private YeastsViewModel _yeastsViewModel;
        private AdditivesViewModel _additivesViewModel;
        private MiscellaneousViewModel _miscellaneousViewModel;
        private WatersViewModel _watersViewModel;
        private CarbonationViewModel _carbonationViewModel;
        private ICommand _navigateMaltsCommand;
        private ICommand _navigateHopsCommand;
        private ICommand _navigateYeastsCommand;
        private ICommand _navigateAdditivesCommand;
        private ICommand _navigateMiscellaneousCommand;
        private ICommand _navigateWatersCommand;
        private ICommand _navigateCarbonationCommand;

        public IngredientsViewModel(MainWindowViewModel mvm)
        {
            _mvm = mvm;
            _maltsViewModel = new MaltsViewModel(mvm);
            _hopsViewModel = new HopsViewModel(mvm);
            _yeastsViewModel = new YeastsViewModel(mvm);
            _additivesViewModel = new AdditivesViewModel(mvm);
            _miscellaneousViewModel = new MiscellaneousViewModel(mvm);
            _watersViewModel = new WatersViewModel(mvm);
            _carbonationViewModel = new CarbonationViewModel(mvm);
            _navigateMaltsCommand = new RelayCommand(_navigateMaltsCommand => NavigateMalts());
            _navigateHopsCommand = new RelayCommand(_navigateHopsCommand => NavigateHops());
            _navigateYeastsCommand = new RelayCommand(_navigateYeastsCommand => NavigateYeats());
            _navigateAdditivesCommand = new RelayCommand(_navigateAdditivesCommand => NavigateAdditives());
            _navigateMiscellaneousCommand = new RelayCommand(_navigateMiscellaneousCommand => NavigateMiscellaneous());
            _navigateWatersCommand = new RelayCommand(_navigateWatersCommand => NavigateWaters());
            _navigateCarbonationCommand = new RelayCommand(_navigateCarbonationCommand => NavigateCarbonation());

            CurrentIngredientsViewModel = _maltsViewModel;
        }


        public void NavigateMalts()
        {
            CurrentIngredientsViewModel = _maltsViewModel;
        }

        public void NavigateHops()
        {
            CurrentIngredientsViewModel = _hopsViewModel;
        }

        public void NavigateYeats()
        {
            CurrentIngredientsViewModel = _yeastsViewModel;
        }

        public void NavigateAdditives()
        {
            CurrentIngredientsViewModel = _additivesViewModel;
        }

        public void NavigateMiscellaneous()
        {
            CurrentIngredientsViewModel = _miscellaneousViewModel;
        }

        public void NavigateWaters()
        {
            CurrentIngredientsViewModel = _watersViewModel;
        }

        public void NavigateCarbonation()
        {
            CurrentIngredientsViewModel = _carbonationViewModel;
        }


        public ICommand NavigateMaltsCommand { get { return _navigateMaltsCommand; } }
        public ICommand NavigateHopsCommand { get { return _navigateHopsCommand; } }
        public ICommand NavigateYeastsCommand { get { return _navigateYeastsCommand; } }
        public ICommand NavigateAdditivesCommand { get { return _navigateAdditivesCommand; } }
        public ICommand NavigateMiscellaneousCommand { get { return _navigateMiscellaneousCommand; } }
        public ICommand NavigateWatersCommand { get { return _navigateWatersCommand; } }
        public ICommand NavigateCarbonationCommand { get { return _navigateCarbonationCommand; } }
        public ViewModelBase CurrentIngredientsViewModel
        {
            get => _currentIngredientsViewModel;
            set
            {
                _currentIngredientsViewModel?.Dispose();
                _currentIngredientsViewModel = value;
                OnCurrentViewModelChanged();
            }
        }


        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentIngredientsViewModel));
        }
    }
}
