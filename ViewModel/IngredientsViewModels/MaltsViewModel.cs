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
    public class MaltsViewModel : ViewModelBase
    {
        private MainWindowViewModel _mvm;
        private ICommand _addMaltCommand;
        private ICommand _deleteMaltCommand;
        private ObservableCollection<Malt> _malts;

        public MaltsViewModel(MainWindowViewModel mvm)
        {
            _mvm = mvm;
            _addMaltCommand = new RelayCommand(_addMaltCommand => AddMalt());
            _deleteMaltCommand = new RelayCommand(_deleteMaltCommand => DeleteMalt(_deleteMaltCommand));
            _malts = new ObservableCollection<Malt>();

            UpdateMalts();
        }


        public void AddMalt()
        {
            View.AddMaltView addMaltView = new View.AddMaltView()
            {
                DataContext = new AddMaltViewModel(_mvm)
            };
            addMaltView.ShowDialog();
            UpdateMalts();
        }

        public void DeleteMalt(object parameter)
        {
            MessageBoxResult accepted = System.Windows.MessageBox.Show("Na pewno usunąć?", "Potwierdzenie usunięcia", System.Windows.MessageBoxButton.YesNo);
            if (accepted == MessageBoxResult.Yes)
            {
                int id = Int32.Parse(parameter.ToString());
                _mvm.DBC.DeleteSingleRow("Malt", "Id", id.ToString());
                _mvm.DB.Malts.Remove(_mvm.DB.Malts.FirstOrDefault(x => x.Id == id));
                UpdateMalts();
            }
        }

        public void UpdateMalts()
        {
            Malts = new ObservableCollection<Malt>();
            Malts = _mvm.DB.Malts;
        }

        public ICommand AddMaltCommand { get { return _addMaltCommand; } }
        public ICommand DeleteMaltCommand { get { return _deleteMaltCommand;} }
        public ObservableCollection<Malt> Malts
        {
            get 
            { 
                return _malts; 
            }
            set
            {
                _malts = value;
                OnPropertyChanged("Malts");
            }
        }
    }
}
