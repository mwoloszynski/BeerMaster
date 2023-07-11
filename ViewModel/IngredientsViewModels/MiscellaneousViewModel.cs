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
    public class MiscellaneousViewModel : ViewModelBase
    {
        private MainWindowViewModel _mvm;
        private ICommand _addMiscCommand;
        private ICommand _deleteMiscCommand;
        private ObservableCollection<Miscellaneous> _miscs;

        public MiscellaneousViewModel(MainWindowViewModel mvm)
        {
            _mvm = mvm;
            _addMiscCommand = new RelayCommand(_addMiscCommand => AddMisc());
            _deleteMiscCommand = new RelayCommand(_deleteMiscCommand => DeleteMisc(_deleteMiscCommand));
            _miscs = new ObservableCollection<Miscellaneous>();

            UpdateMiscs();
        }

        public void AddMisc()
        {
            View.AddMiscellaneousView addMiscellaneousView = new View.AddMiscellaneousView()
            {
                DataContext = new AddMiscellaneousViewModel(_mvm)
            };
            addMiscellaneousView.ShowDialog();
            UpdateMiscs();
        }

        public void DeleteMisc(object parameter)
        {
            MessageBoxResult accepted = System.Windows.MessageBox.Show("Na pewno usunąć?", "Potwierdzenie usunięcia", System.Windows.MessageBoxButton.YesNo);
            if (accepted == MessageBoxResult.Yes)
            {
                int id = Int32.Parse(parameter.ToString());
                _mvm.DBC.DeleteSingleRow("Miscellaneous", "Id", id.ToString());
                _mvm.DB.Miscellaneous.Remove(_mvm.DB.Miscellaneous.FirstOrDefault(x => x.Id == id));
                UpdateMiscs();
            }
        }

        public void UpdateMiscs()
        {
            Miscs = new ObservableCollection<Miscellaneous>();
            Miscs = _mvm.DB.Miscellaneous;
        }


        public ICommand AddMiscCommand { get { return _addMiscCommand; } }
        public ICommand DeleteMiscCommand { get { return _deleteMiscCommand; } }
        public ObservableCollection<Miscellaneous> Miscs
        {
            get
            {
                return _miscs;
            }
            set
            {
                _miscs = value;
                OnPropertyChanged("Miscs");
            }
        }
    }
}
