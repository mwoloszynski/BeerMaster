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
    public class HopsViewModel : ViewModelBase
    {
        private MainWindowViewModel _mvm;
        private ICommand _addHopCommand;
        private ICommand _deleteHopCommand;
        private ObservableCollection<Hop> _hops;

        public HopsViewModel(MainWindowViewModel mvm)
        {
            _mvm = mvm;
            _addHopCommand = new RelayCommand(_addHopCommand => AddHop());
            _deleteHopCommand = new RelayCommand(_deleteHopCommand => DeleteHop(_deleteHopCommand));
            _hops = new ObservableCollection<Hop>();

            UpdateHops();
        }

        public void AddHop()
        {
            View.AddHopView addHopView = new View.AddHopView()
            {
                DataContext = new AddHopViewModel(_mvm)
            };
            addHopView.ShowDialog();
            UpdateHops();
        }

        public void DeleteHop(object parameter)
        {
            MessageBoxResult accepted = System.Windows.MessageBox.Show("Na pewno usunąć?", "Potwierdzenie usunięcia", System.Windows.MessageBoxButton.YesNo);
            if (accepted == MessageBoxResult.Yes)
            {
                int id = Int32.Parse(parameter.ToString());
                _mvm.DBC.DeleteSingleRow("Hop", "Id", id.ToString());
                _mvm.DB.Hops.Remove(_mvm.DB.Hops.FirstOrDefault(x => x.Id == id));
                UpdateHops();
            }
        }

        public void UpdateHops()
        {
            Hops = new ObservableCollection<Hop>();
            Hops = _mvm.DB.Hops;
        }


        public ICommand AddHopCommand { get { return _addHopCommand; } }
        public ICommand DeleteHopCommand { get { return _deleteHopCommand; } }
        public ObservableCollection<Hop> Hops
        {
            get
            {
                return _hops;
            }
            set
            {
                _hops = value;
                OnPropertyChanged("Hops");
            }
        }
    }
}
