using BeerMaster.Controllers;
using BeerMaster.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BeerMaster.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        private Settings _settings;
        private DBController _dbc;
        private DB _db;
        private ViewModelBase _currentViewModel;
        private HomeViewModel _homeViewModel;
        private BrewViewModel _brewViewModel;
        private IngredientsViewModel _ingredientsViewModel;
        private RecipesViewModel _recipesViewModel;
        private SettingsViewModel _settingsViewModel;
        private StylesViewModel _stylesViewModel;
        private int _selectedViewIndex;

        public MainWindowViewModel(Settings settings, DBController dbc, DB db)
        {
            _settings = settings;
            _dbc = dbc;
            _db = db;
            _homeViewModel = new HomeViewModel(this);
            _brewViewModel = new BrewViewModel(this);
            _settingsViewModel = new SettingsViewModel(this);
            _recipesViewModel = new RecipesViewModel(this);
            _stylesViewModel = new StylesViewModel(this);
            _ingredientsViewModel = new IngredientsViewModel(this);

            SelectedViewIndex = 0;
            CurrentViewModel = _homeViewModel;
        }

        private void Navigate(int index)
        {
            switch (index)
            {
                case 0:
                    NavigateHome();
                    break;
                case 1:
                    CurrentViewModel = _brewViewModel;
                    break;
                case 2:
                    CurrentViewModel = _recipesViewModel;
                    break;
                case 3:
                    CurrentViewModel = _stylesViewModel;
                    break;
                case 4:
                    CurrentViewModel = _ingredientsViewModel;
                    break;
                case 5:
                    CurrentViewModel = _settingsViewModel;
                    break;
                default:
                    NavigateHome();
                    break;
            }
        }

        public void NavigateHome()
        {
            CurrentViewModel = _homeViewModel;
        }


        public DBController DBC
        {
            get
            {
                return _dbc;
            }
            set
            {
                _dbc = value;
                OnPropertyChanged("DBC");
            }
        }
        public DB DB
        {
            get
            {
                return _db;
            }
            set
            {
                _db = value;
                OnPropertyChanged("DB");
            }
        }
        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel?.Dispose();
                _currentViewModel = value;
                OnCurrentViewModelChanged();
            }
        }
        public int SelectedViewIndex 
        {
            get => _selectedViewIndex;
            set
            {
                _selectedViewIndex = value;
                OnPropertyChanged(nameof(SelectedViewIndex));
                Navigate(value);
            }
        }


        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
