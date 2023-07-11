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
    public class WatersViewModel : ViewModelBase
    {
        private MainWindowViewModel _mvm;
        private ICommand _addWaterCommand;
        private ICommand _deleteWaterCommand;
        private ObservableCollection<Water> _waters;

        public WatersViewModel(MainWindowViewModel mvm)
        {
            _mvm = mvm;
            _addWaterCommand = new RelayCommand(_addWaterCommand => AddWater());
            _deleteWaterCommand = new RelayCommand(_deleteWaterCommand => DeleteWater(_deleteWaterCommand));
            _waters = new ObservableCollection<Water>();

            UpdateWaters();
        }

        public void AddWater()
        {
            View.AddWaterView addWaterView = new View.AddWaterView()
            {
                DataContext = new AddWaterViewModel(_mvm)
            };
            addWaterView.ShowDialog();
            UpdateWaters();
        }

        public void DeleteWater(object parameter)
        {
            MessageBoxResult accepted = System.Windows.MessageBox.Show("Na pewno usunąć?", "Potwierdzenie usunięcia", System.Windows.MessageBoxButton.YesNo);
            if (accepted == MessageBoxResult.Yes)
            {
                int id = Int32.Parse(parameter.ToString());
                _mvm.DBC.DeleteSingleRow("Water", "Id", id.ToString());
                _mvm.DB.Waters.Remove(_mvm.DB.Waters.FirstOrDefault(x => x.Id == id));
                UpdateWaters();
            }
        }

        public void UpdateWaters()
        {
            Waters = new ObservableCollection<Water>();
            Waters = _mvm.DB.Waters;
        }


        public ICommand AddWaterCommand { get { return _addWaterCommand; } }
        public ICommand DeleteWaterCommand { get { return _deleteWaterCommand; } }
        public ObservableCollection<Water> Waters
        {
            get
            {
                return _waters;
            }
            set
            {
                _waters = value;
                OnPropertyChanged("Waters");
            }
        }
    }
}
