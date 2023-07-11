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
    public class AddAdditiveViewModel : ViewModelBase, ICloseWindow
    {
        private MainWindowViewModel _mvm;
        private ICommand _closeCommand;
        private ICommand _saveCommand;
        private string _name;
        private string _type;
        private string _country;
        private string _supplier;
        private string _color;
        private string _maxGrist;
        private string _sugar;
        private string _potential;
        private string _yield;
        private string _bitterness;
        private string _description;
        private string _pricePerL_KG;

        public AddAdditiveViewModel(MainWindowViewModel mvm)
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
            if (string.IsNullOrEmpty(Sugar))
                Sugar = "0";
            if (string.IsNullOrEmpty(Potential))
                Potential = "100";
            if (string.IsNullOrEmpty(Yield))
                Yield = "100";
            if (string.IsNullOrEmpty(Bitterness))
                Bitterness = "0";
            if (string.IsNullOrEmpty(PricePerL_Kg))
                PricePerL_Kg = "0";

            if (!string.IsNullOrEmpty(Name))
            {
                float additiveColorTemp = float.Parse(Color, System.Globalization.CultureInfo.InvariantCulture);
                float additiveMaxGristTemp = float.Parse(MaxGrist, System.Globalization.CultureInfo.InvariantCulture);
                float additiveSugarTemp = float.Parse(Sugar, System.Globalization.CultureInfo.InvariantCulture);
                float additivePotentialTemp = float.Parse(Potential, System.Globalization.CultureInfo.InvariantCulture);
                float additiveYieldTemp = float.Parse(Yield, System.Globalization.CultureInfo.InvariantCulture);
                float additiveBitternessTemp = float.Parse(Bitterness, System.Globalization.CultureInfo.InvariantCulture);
                float additivePriceTemp = float.Parse(PricePerL_Kg, System.Globalization.CultureInfo.InvariantCulture);

                float additiveColor = (float)Math.Ceiling(additiveColorTemp * 100f) / 100f;
                float additiveMaxGrist = (float)Math.Ceiling(additiveMaxGristTemp * 100f) / 100f;
                float additiveSugar = (float)Math.Ceiling(additiveSugarTemp * 100f) / 100f;
                float additivePotential = (float)Math.Ceiling(additivePotentialTemp * 100f) / 100f;
                float additiveYield = (float)Math.Ceiling(additiveYieldTemp * 100f) / 100f;
                float additiveBitterness = (float)Math.Ceiling(additiveBitternessTemp * 100f) / 100f;
                float additivePrice = (float)Math.Ceiling(additivePriceTemp * 100f) / 100f;


                string[] newAdditiveColumns = { "Name", "Type", "Country", "Supplier", "Color", "MaxGrist", "Sugar", "Potential", "Yield", "Bitterness", "Description", "PricePerL_Kg" };
                string[] newAdditiveValues = { Name, Type, Country, Supplier, additiveColor.ToString(), additiveMaxGrist.ToString(), additiveSugar.ToString(), additivePotential.ToString(), additiveYield.ToString(), additiveBitterness.ToString(), Description, additivePrice.ToString() };
                string tableName = "Additives";

                _mvm.DBC.InsertIntoTable(tableName, newAdditiveColumns, newAdditiveValues);
                var id = _mvm.DBC.SelectSingleColumnOneResult(tableName, "ORDER BY Id DESC LIMIT 1", "Id");

                _mvm.DB.Additives.Add(new Model.DBModel.Additives
                {
                    Id = Int32.Parse(id),
                    Name = Name,
                    Type = Type,
                    Country = Country,
                    Supplier = Supplier,
                    Color = additiveColor,
                    MaxGrist = additiveMaxGrist,
                    Sugar = additiveSugar,
                    Potential = additivePotential,
                    Yield = additiveYield,
                    Bitterness = additiveBitterness,
                    Description = Description,
                    PricePerL_Kg = additivePrice
                });
                _mvm.DB.SortAdditives();

                MessageBox.Show("Dodano dodatek");
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
        public string Supplier { get { return _supplier; } set { _supplier = value; OnPropertyChanged("Supplier"); } }
        public string Color { get { return _color; } set { _color = value; OnPropertyChanged("Color"); } }
        public string MaxGrist { get { return _maxGrist; } set { _maxGrist = value; OnPropertyChanged("MaxGrist"); } }
        public string Sugar { get { return _sugar; } set { _sugar = value; OnPropertyChanged("Sugar"); } }
        public string Potential { get { return _potential; } set { _potential = value; OnPropertyChanged("Potential"); } }
        public string Yield { get { return _yield; } set { _yield = value; OnPropertyChanged("Yield"); } }
        public string Bitterness { get { return _bitterness; } set { _bitterness = value; OnPropertyChanged("Bitterness"); } }
        public string PricePerL_Kg { get { return _pricePerL_KG; } set { _pricePerL_KG = value; OnPropertyChanged("PricePerL_Kg"); } }

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
