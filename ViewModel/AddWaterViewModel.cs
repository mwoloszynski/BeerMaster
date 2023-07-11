using BeerMaster.Model.Interfaces;
using BeerMaster.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Diagnostics.Metrics;
using System.Windows;

namespace BeerMaster.ViewModel
{
    public class AddWaterViewModel : ViewModelBase, ICloseWindow
    {
        private MainWindowViewModel _mvm;
        private ICommand _closeCommand;
        private ICommand _saveCommand;
        private string _name;
        private string _PH;
        private string _calcium;
        private string _magnesium;
        private string _sodium;
        private string _sulfate;
        private string _chloride;
        private string _bicarbonate;
        private string _description;
        private string _pricePerLiter;

        public AddWaterViewModel(MainWindowViewModel mvm)
        {
            _mvm = mvm;
            _closeCommand = new RelayCommand(_closeCommand => CloseWindow());
            _saveCommand = new RelayCommand(_saveCommand => Save());
        }

        public void Save()
        {
            if (string.IsNullOrEmpty(PH))
                PH = "7";
            if (string.IsNullOrEmpty(Calcium))
                Calcium = "0";
            if (string.IsNullOrEmpty(Magnesium))
                Magnesium = "0";
            if (string.IsNullOrEmpty(Sodium))
                Sodium = "0";
            if (string.IsNullOrEmpty(Sulfate))
                Sulfate = "0";
            if (string.IsNullOrEmpty(Chloride))
                Chloride = "0";
            if (string.IsNullOrEmpty(Bicarbonate))
                Bicarbonate = "0";
            if (string.IsNullOrEmpty(PricePerLiter))
                PricePerLiter = "0";

            if (!string.IsNullOrEmpty(Name))
            {
                float waterPHTemp = float.Parse(PH, System.Globalization.CultureInfo.InvariantCulture);
                float waterCalciumTemp = float.Parse(Calcium, System.Globalization.CultureInfo.InvariantCulture);
                float waterMagnesiumTemp = float.Parse(Magnesium, System.Globalization.CultureInfo.InvariantCulture);
                float waterSodiumTemp = float.Parse(Sodium, System.Globalization.CultureInfo.InvariantCulture);
                float waterSulfateTemp = float.Parse(Sulfate, System.Globalization.CultureInfo.InvariantCulture);
                float waterChlorideTemp = float.Parse(Chloride, System.Globalization.CultureInfo.InvariantCulture);
                float waterBicarbonateTemp = float.Parse(Bicarbonate, System.Globalization.CultureInfo.InvariantCulture);
                float waterPriceTemp = float.Parse(PricePerLiter, System.Globalization.CultureInfo.InvariantCulture);


                float waterPH = (float)Math.Ceiling(waterPHTemp * 100f) / 100f;
                float waterCalcium = (float)Math.Ceiling(waterCalciumTemp * 100f) / 100f;
                float waterMagnesium = (float)Math.Ceiling(waterMagnesiumTemp * 100f) / 100f;
                float waterSodium = (float)Math.Ceiling(waterSodiumTemp * 100f) / 100f;
                float waterSulfate = (float)Math.Ceiling(waterSulfateTemp * 100f) / 100f;
                float waterChloride = (float)Math.Ceiling(waterChlorideTemp * 100f) / 100f;
                float waterBicarbonate = (float)Math.Ceiling(waterBicarbonateTemp * 100f) / 100f;
                float waterPrice = (float)Math.Ceiling(waterPriceTemp * 100f) / 100f;


                string[] newWaterColumns = { "Name", "PH", "Calcium", "Magnesium", "Sodium", "Sulfate", "Chloride", "Bicarbonate", "Description", "PricePerLiter" };
                string[] newWaterValues = { Name, waterPH.ToString(), waterCalcium.ToString(), waterMagnesium.ToString(), waterSodium.ToString(), waterSulfate.ToString(), waterChloride.ToString(), waterBicarbonate.ToString(), Description, waterPrice.ToString() };
                string tableName = "Water";

                _mvm.DBC.InsertIntoTable(tableName, newWaterColumns, newWaterValues);
                var id = _mvm.DBC.SelectSingleColumnOneResult(tableName, "ORDER BY Id DESC LIMIT 1", "Id");

                _mvm.DB.Waters.Add(new Model.DBModel.Water
                {
                    Id = Int32.Parse(id),
                    Name = Name,
                    PH = waterPH,
                    Calcium = waterCalcium,
                    Magnesium = waterMagnesium,
                    Sodium = waterSodium,
                    Sulfate = waterSulfate,
                    Chloride = waterChloride,
                    Bicarbonate = waterBicarbonate,
                    Description = Description,
                    PricePerLiter = waterPrice
                });
                _mvm.DB.SortWaters();

                MessageBox.Show("Dodano wode");
                CloseWindow();
            }
            else
            {
                // Obsługa błędów;
            }
        }


        public string Name { get { return _name; } set { _name = value; OnPropertyChanged("Name"); } }
        public string PH { get { return _PH; } set { _PH = value; OnPropertyChanged("PH"); } }
        public string Calcium { get { return _calcium; } set { _calcium = value; OnPropertyChanged("Calcium"); } }
        public string Magnesium { get { return _magnesium; } set { _magnesium = value; OnPropertyChanged("Magnesium"); } }
        public string Sodium { get { return _sodium; } set { _sodium = value; OnPropertyChanged("Sodium"); } }
        public string Sulfate { get { return _sulfate; } set { _sulfate = value; OnPropertyChanged("Sulfate"); } }
        public string Chloride { get { return _chloride; } set { _chloride = value; OnPropertyChanged("Chloride"); } }
        public string Bicarbonate { get { return _bicarbonate; } set { _bicarbonate = value; OnPropertyChanged("Bicarbonate"); } }
        public string Description { get { return _description; } set { _description = value; OnPropertyChanged("Description"); } }
        public string PricePerLiter { get { return _pricePerLiter; } set { _pricePerLiter = value; OnPropertyChanged("PricePerLiter"); } }

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
