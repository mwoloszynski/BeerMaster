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
    public class YeastsViewModel : ViewModelBase
    {
        private MainWindowViewModel _mvm;
        private ICommand _addYeastCommand;
        private ICommand _deleteYeastCommand;
        private ObservableCollection<Yeast> _yeasts;

        public YeastsViewModel(MainWindowViewModel mvm)
        {
            _mvm = mvm;
            _addYeastCommand = new RelayCommand(_addYeastCommand => AddYeast());
            _deleteYeastCommand = new RelayCommand(_deleteYeastCommand => DeleteYeast(_deleteYeastCommand));
            _yeasts = new ObservableCollection<Yeast>();

            UpdateYeasts();
        }

        public void AddYeast()
        {
            View.AddYeastView addYeastView = new View.AddYeastView()
            {
                DataContext = new AddYeastViewModel(_mvm)
            };
            addYeastView.ShowDialog();
            UpdateYeasts();
        }

        public void DeleteYeast(object parameter)
        {
            MessageBoxResult accepted = System.Windows.MessageBox.Show("Na pewno usunąć?", "Potwierdzenie usunięcia", System.Windows.MessageBoxButton.YesNo);
            if (accepted == MessageBoxResult.Yes)
            {
                int id = Int32.Parse(parameter.ToString());
                _mvm.DBC.DeleteSingleRow("Yeast", "Id", id.ToString());
                _mvm.DB.Yeasts.Remove(_mvm.DB.Yeasts.FirstOrDefault(x => x.Id == id));
                UpdateYeasts();
            }
        }

        public void UpdateYeasts()
        {
            Yeasts = new ObservableCollection<Yeast>();
            Yeasts = _mvm.DB.Yeasts;
        }


        public ICommand AddYeastCommand { get { return _addYeastCommand; } }
        public ICommand DeleteYeastCommand { get { return _deleteYeastCommand; } }
        public ObservableCollection<Yeast> Yeasts
        {
            get
            {
                return _yeasts;
            }
            set
            {
                _yeasts = value;
                OnPropertyChanged("Yeasts");
            }
        }
    }
}
