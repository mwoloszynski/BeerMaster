using BeerMaster.Model;
using BeerMaster.Model.DBModel;
using BeerMaster.View;
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
    public class AdditivesViewModel : ViewModelBase
    {
        private MainWindowViewModel _mvm;
        private ICommand _addAdditiveCommand;
        private ICommand _deleteAdditiveCommand;
        private ObservableCollection<Additives> _additives;

        public AdditivesViewModel(MainWindowViewModel mvm)
        {
            _mvm = mvm;
            _addAdditiveCommand = new RelayCommand(_addAdditiveCommand => AddAdditive());
            _deleteAdditiveCommand = new RelayCommand(_deleteAdditiveCommand => DeleteAdditive(_deleteAdditiveCommand));
            _additives = new ObservableCollection<Additives>();

            UpdateAdditives();
        }

        public void AddAdditive()
        {
            View.AddAdditiveView addAdditiveView = new View.AddAdditiveView()
            {
                DataContext = new AddAdditiveViewModel(_mvm)
            };
            addAdditiveView.ShowDialog();
            UpdateAdditives();
        }

        public void DeleteAdditive(object parameter)
        {
            MessageBoxResult accepted = System.Windows.MessageBox.Show("Na pewno usunąć?", "Potwierdzenie usunięcia", System.Windows.MessageBoxButton.YesNo);
            if (accepted == MessageBoxResult.Yes)
            {
                int id = Int32.Parse(parameter.ToString());
                _mvm.DBC.DeleteSingleRow("Additives", "Id", id.ToString());
                _mvm.DB.Additives.Remove(_mvm.DB.Additives.FirstOrDefault(x => x.Id == id));
                UpdateAdditives();
            }
        }

        public void UpdateAdditives()
        {
            Additives = new ObservableCollection<Additives>();
            Additives = _mvm.DB.Additives;
        }

        public ICommand AddAdditiveCommand { get { return _addAdditiveCommand; } }
        public ICommand DeleteAdditiveCommand { get { return _deleteAdditiveCommand; } }
        public ObservableCollection<Additives> Additives
        {
            get
            {
                return _additives;
            }
            set
            {
                _additives = value;
                OnPropertyChanged("Additives");
            }
        }
    }
}
