using BeerMaster.Model;
using BeerMaster.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BeerMaster.ViewModel
{
    public class AddMaltViewModel : ViewModelBase, ICloseWindow
    {
        private MainWindowViewModel _mvm;
        private ICommand _closeCommand;
        private ICommand _saveCommand;
        private string _name;
        private string _description;
        private string _type;
        private string _country;
        private string _supplier;
        private string _color;
        private string _maxGrist;
        private string _extract;
        private string _pricePerKg;


        public AddMaltViewModel(MainWindowViewModel mvm)
        {
            _mvm = mvm;
            _closeCommand = new RelayCommand(_closeCommand => CloseWindow());
            _saveCommand = new RelayCommand(_saveCommand => Save());
        }


        public void Save()
        {
            if (string.IsNullOrEmpty(Color))
                Color = "0";
            if (string.IsNullOrEmpty(MaxGrist))
                MaxGrist = "100";
            if(string.IsNullOrEmpty(Extract))
                Extract = "100";
            if(string.IsNullOrEmpty(PricePerKg))
                PricePerKg = "0";
            if(!string.IsNullOrEmpty(Name)) 
            {
                float maltColorTemp = float.Parse(Color, System.Globalization.CultureInfo.InvariantCulture);
                float maltPriceTemp = float.Parse(PricePerKg, System.Globalization.CultureInfo.InvariantCulture);
                float maltExtractTemp = float.Parse(Extract, System.Globalization.CultureInfo.InvariantCulture);
                float maltMaxGristTemp = float.Parse(MaxGrist, System.Globalization.CultureInfo.InvariantCulture);

                float maltColor = (float)Math.Ceiling(maltColorTemp * 100f) / 100f;
                float maltPrice = (float)Math.Ceiling(maltPriceTemp * 100f) / 100f;
                float maltExtract = (float)Math.Ceiling(maltExtractTemp * 100f) / 100f;
                float maltMaxGrist = (float)Math.Ceiling(maltMaxGristTemp * 100f) / 100f;

                string[] newMaltColumns = { "Name", "Type", "Country", "Supplier", "Color", "MaxGrist", "Extract", "Description", "PricePerKg" };
                string[] newMaltValues = { Name, Type, Country, Supplier, maltColor.ToString(), maltMaxGrist.ToString(), maltExtract.ToString(), Description, maltPrice.ToString() };
                string tableName = "Malt";

                _mvm.DBC.InsertIntoTable(tableName, newMaltColumns, newMaltValues);
                var id = _mvm.DBC.SelectSingleColumnOneResult(tableName, "ORDER BY Id DESC LIMIT 1", "Id");

                _mvm.DB.Malts.Add(new Model.DBModel.Malt
                {
                    Id = Int32.Parse(id),
                    Name = Name,
                    Type = Type,
                    Country = Country,
                    Supplier = Supplier,
                    Color = maltColor,
                    MaxGrist = maltMaxGrist,
                    Extract = maltExtract,
                    Description = Description,
                    PricePerKg = maltPrice,
                });
                _mvm.DB.SortMalts();

                MessageBox.Show("Dodano słód");
                CloseWindow();
            }
            else
            {
                // Obsługa błędów;
            }
        }


        public string Name { get { return _name; } set {  _name = value; OnPropertyChanged("Name"); } }
        public string Description { get { return _description; } set { _description = value; OnPropertyChanged("Description"); } }
        public string Type { get { return _type; } set { _type = value; OnPropertyChanged("Type"); } }
        public string Country { get { return _country; } set { _country = value; OnPropertyChanged("Country"); } }
        public string Supplier { get { return _supplier; } set { _supplier = value; OnPropertyChanged("Supplier"); } }
        public string Color { get { return _color; } set { _color = value; OnPropertyChanged("Color");  } }
        public string MaxGrist { get {  return _maxGrist; } set { _maxGrist = value; OnPropertyChanged("MaxGrist"); } }
        public string Extract { get { return _extract; } set { _extract = value; OnPropertyChanged("Extract"); } }
        public string PricePerKg { get { return _pricePerKg; } set { _pricePerKg = value; OnPropertyChanged("PricePerKg"); } }

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
