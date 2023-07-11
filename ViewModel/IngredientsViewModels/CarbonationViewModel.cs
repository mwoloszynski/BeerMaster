using BeerMaster.Model;
using BeerMaster.Model.DBModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BeerMaster.ViewModel.IngredientsViewModels
{
    public class CarbonationViewModel : ViewModelBase
    {
        private MainWindowViewModel _mvm;
        private ICommand _addCarbonationCommand;
        private ICommand _deleteCarbonationCommand;
        private ObservableCollection<Carbonation> _carbonations;

        public CarbonationViewModel(MainWindowViewModel mvm)
        {
            _mvm = mvm;
            _addCarbonationCommand = new RelayCommand(_addCarbonationCommand => AddCarbonation());
            _deleteCarbonationCommand = new RelayCommand(_deleteCarbonationCommand => DeleteCarbonation(_deleteCarbonationCommand));
            _carbonations = new ObservableCollection<Carbonation>();

            UpdateCarbonations();
        }

        public void AddCarbonation()
        {
            View.AddCarbonationView addCarbonationView = new View.AddCarbonationView()
            {
                DataContext = new AddCarbonationViewModel(_mvm)
            };
            addCarbonationView.ShowDialog();
            UpdateCarbonations();
        }

        public void DeleteCarbonation(object parameter)
        {
            MessageBoxResult accepted = System.Windows.MessageBox.Show("Na pewno usunąć?", "Potwierdzenie usunięcia", System.Windows.MessageBoxButton.YesNo);
            if (accepted == MessageBoxResult.Yes)
            {
                int id = Int32.Parse(parameter.ToString());
                _mvm.DBC.DeleteSingleRow("Carbonation", "Id", id.ToString());
                _mvm.DB.Carbonations.Remove(_mvm.DB.Carbonations.FirstOrDefault(x => x.Id == id));
                UpdateCarbonations();
            }
        }

        public void UpdateCarbonations()
        {
            Carbonations = new ObservableCollection<Carbonation>();
            Carbonations = _mvm.DB.Carbonations;
        }

        public ICommand AddCarbonationCommand { get { return _addCarbonationCommand; } }
        public ICommand DeleteCarbonationCommand { get { return _deleteCarbonationCommand; } }
        public ObservableCollection<Carbonation> Carbonations
        {
            get
            {
                return _carbonations;
            }
            set
            {
                _carbonations = value;
                OnPropertyChanged("Carbonations");
            }
        }
    }
}
