using BeerMaster.Model;
using BeerMaster.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BeerMaster.ViewModel
{
    public class AddYeastViewModel : ViewModelBase, ICloseWindow
    {
        private MainWindowViewModel _mvm;
        private ICommand _closeCommand;
        private ICommand _saveCommand;
        private string _name;
        private string _beerCategory;
        private string _supplier;
        private string _type;
        private string _dosageAmountGram;
        private string _dosagePerAmountLiters;
        private string _minTemperature;
        private string _maxTemperature;
        private string _attenuation;
        private string _flocculation;
        private string _description;
        private string _pricePerPackage;

        public AddYeastViewModel(MainWindowViewModel mvm)
        {

            _mvm = mvm;
            _closeCommand = new RelayCommand(_closeCommand => CloseWindow());
            _saveCommand = new RelayCommand(_saveCommand => Save());
        }

        public void Save()
        {
            if (string.IsNullOrEmpty(DosageAmountGram))
                DosageAmountGram = "0";
            if (string.IsNullOrEmpty(DosagePerAmountLiters))
                DosagePerAmountLiters = "0";
            if (string.IsNullOrEmpty(MinTemperature))
                MinTemperature = "0";
            if (string.IsNullOrEmpty(MaxTemperature))
                MaxTemperature = "100";
            if (string.IsNullOrEmpty(Flocculation))
                Flocculation = "100";
            if (string.IsNullOrEmpty(Attenuation))
                Attenuation = "100";
            if (string.IsNullOrEmpty(PricePerPackage))
                PricePerPackage = "0";
            if (!string.IsNullOrEmpty(Name))
            {
                float yeastDosageTemp = float.Parse(DosageAmountGram, System.Globalization.CultureInfo.InvariantCulture);
                float yeastDosagePerAmountTemp = float.Parse(DosagePerAmountLiters, System.Globalization.CultureInfo.InvariantCulture);
                float yeastMinTemperatureTemp = float.Parse(MinTemperature, System.Globalization.CultureInfo.InvariantCulture);
                float yeastMaxTemperatureTemp = float.Parse(MaxTemperature, System.Globalization.CultureInfo.InvariantCulture);
                float yeastFlocculationTemp = float.Parse(Flocculation, System.Globalization.CultureInfo.InvariantCulture);
                float yeastAttencuationTemp = float.Parse(Attenuation, System.Globalization.CultureInfo.InvariantCulture);
                float yeastPriceTemp = float.Parse(PricePerPackage, System.Globalization.CultureInfo.InvariantCulture);

                float yeastDosage = (float)Math.Ceiling(yeastDosageTemp * 100f) / 100f;
                float yeastDosagePerAmount = (float)Math.Ceiling(yeastDosagePerAmountTemp * 100f) / 100f;
                float yeastMinTemperature = (float)Math.Ceiling(yeastMinTemperatureTemp * 100f) / 100f;
                float yeastMaxTemperature = (float)Math.Ceiling(yeastMaxTemperatureTemp * 100f) / 100f;
                float yeastFlocculation = (float)Math.Ceiling(yeastFlocculationTemp * 100f) / 100f;
                float yeastAttencuation = (float)Math.Ceiling(yeastAttencuationTemp * 100f) / 100f;
                float yeastPrice = (float)Math.Ceiling(yeastPriceTemp * 100f) / 100f;

                string[] newYeastColumns = { "Name", "BeerCategory", "Supplier", "Type", "DosageAmountGram", "DosagePerAmountLiters", "MinTemperature", "MaxTemperature", "Attenuation", "Flocculation", "Description", "PricePerPackage" };
                string[] newYeastValues = { Name, BeerCategory, Supplier, Type, yeastDosage.ToString(), yeastDosagePerAmount.ToString(), yeastMinTemperature.ToString(), yeastMaxTemperature.ToString(), yeastAttencuation.ToString(), yeastFlocculation.ToString(), Description, yeastPrice.ToString() };
                string tableName = "Yeast";

                _mvm.DBC.InsertIntoTable(tableName, newYeastColumns, newYeastValues);
                var id = _mvm.DBC.SelectSingleColumnOneResult(tableName, "ORDER BY Id DESC LIMIT 1", "Id");

                _mvm.DB.Yeasts.Add(new Model.DBModel.Yeast
                {
                    Id = Int32.Parse(id),
                    Name = Name,
                    BeerCategory = BeerCategory,
                    Supplier = Supplier,
                    Type = Type,
                    DosageAmountGram = yeastDosage,
                    DosagePerAmountLiters = yeastDosagePerAmount,
                    MinTemperature = yeastMinTemperature,
                    MaxTemperature = yeastMaxTemperature,
                    Attenuation = yeastAttencuation,
                    Flocculation = yeastFlocculation,
                    Description = Description,
                    PricePerPackage = yeastPrice
                });
                _mvm.DB.SortYeasts();

                MessageBox.Show("Dodano drożdże");
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
        public string BeerCategory { get { return _beerCategory; } set { _beerCategory = value; OnPropertyChanged("BeerCategory"); } }
        public string Supplier { get { return _supplier; } set { _supplier = value; OnPropertyChanged("Supplier"); } }
        public string DosageAmountGram { get { return _dosageAmountGram; } set { _dosageAmountGram = value; OnPropertyChanged("DosageAmountGram"); } }
        public string DosagePerAmountLiters { get { return _dosagePerAmountLiters; } set { _dosagePerAmountLiters = value; OnPropertyChanged("DosagePerAmountLiters"); } }
        public string MinTemperature { get { return _minTemperature; } set { _minTemperature = value; OnPropertyChanged("MinTemperature"); } }
        public string MaxTemperature { get { return _maxTemperature; } set { _maxTemperature = value; OnPropertyChanged("MaxTemperature"); } }
        public string Attenuation { get { return _attenuation; } set { _attenuation = value; OnPropertyChanged("Attenuation"); } }
        public string Flocculation { get { return _flocculation; } set { _flocculation = value; OnPropertyChanged("Flocculation"); } }
        public string PricePerPackage { get { return _pricePerPackage; } set { _pricePerPackage = value; OnPropertyChanged("PricePerPackage"); } }

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
