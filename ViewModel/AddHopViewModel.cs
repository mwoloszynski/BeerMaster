using BeerMaster.Model.Interfaces;
using BeerMaster.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace BeerMaster.ViewModel
{
    public class AddHopViewModel : ViewModelBase, ICloseWindow
    {
        private MainWindowViewModel _mvm;
        private ICommand _closeCommand;
        private ICommand _saveCommand;
        private string _name;
        private string _description;
        private string _type;
        private string _country;
        private string _alpha;
        private string _beta;
        private string _pricePerGram;

        public AddHopViewModel(MainWindowViewModel mvm)
        {
            _mvm = mvm;
            _closeCommand = new RelayCommand(_closeCommand => CloseWindow());
            _saveCommand = new RelayCommand(_saveCommand => Save());
        }

        public void Save()
        {
            if (string.IsNullOrEmpty(Alpha))
                Alpha = "0";
            if (string.IsNullOrEmpty(Beta))
                Beta = "0";
            if (string.IsNullOrEmpty(PricePerGram))
                PricePerGram = "0";
            if (!string.IsNullOrEmpty(Name))
            {
                float hopAlphaTemp = float.Parse(Alpha, System.Globalization.CultureInfo.InvariantCulture);
                float hopBetaTemp = float.Parse(Beta, System.Globalization.CultureInfo.InvariantCulture);
                float hopPriceTemp = float.Parse(PricePerGram, System.Globalization.CultureInfo.InvariantCulture);

                float hopAlpha = (float)Math.Ceiling(hopAlphaTemp * 100f) / 100f;
                float hopBeta = (float)Math.Ceiling(hopBetaTemp * 100f) / 100f;
                float hopPrice = (float)Math.Ceiling(hopPriceTemp * 100f) / 100f;

                string[] newMaltColumns = { "Name", "Type", "Country", "Alpha", "Beta", "Description", "PricePerGram" };
                string[] newMaltValues = { Name, Type, Country, hopAlpha.ToString(), hopBeta.ToString(), Description, hopPrice.ToString() };
                string tableName = "Hop";

                _mvm.DBC.InsertIntoTable(tableName, newMaltColumns, newMaltValues);
                var id = _mvm.DBC.SelectSingleColumnOneResult(tableName, "ORDER BY Id DESC LIMIT 1", "Id");

                _mvm.DB.Hops.Add(new Model.DBModel.Hop
                {
                    Id = Int32.Parse(id),
                    Name = Name,
                    Type = Type,
                    Country = Country,
                    Alpha = hopAlpha,
                    Beta = hopBeta,
                    Description = Description,
                    PricePerGram = hopPrice
                });
                _mvm.DB.SortHops();

                MessageBox.Show("Dodano chmiel");
                CloseWindow();
            }
            else
            {
                // Obsługa błędów;
            }
        }


        public string Name { get { return _name; } set { _name = value; OnPropertyChanged("Name"); } }
        public string Description { get { return _description; } set { _description = value; OnPropertyChanged("Description"); } }
        public string Type { get { return _type; } set { _type = value; OnPropertyChanged("Type"); } }
        public string Country { get { return _country; } set { _country = value; OnPropertyChanged("Country"); } }
        public string Alpha { get { return _alpha; } set { _alpha = value; OnPropertyChanged("Alpha"); } }
        public string Beta { get { return _beta; } set { _beta = value; OnPropertyChanged("Beta"); } }
        public string PricePerGram { get { return _pricePerGram; } set { _pricePerGram = value; OnPropertyChanged("PricePerGram"); } }

        public void CloseWindow()
        {
            Close?.Invoke();
        }

        public ICommand CloseCommand { get { return _closeCommand; } }
        public ICommand SaveCommand { get { return _saveCommand; } }

        public Action Close { get; set; }

        public bool CanClose()
        {
            return true;
        }
    }
}
