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
using System.Xml.Linq;

namespace BeerMaster.ViewModel
{
    public class AddCarbonationViewModel : ViewModelBase, ICloseWindow
    {
        private MainWindowViewModel _mvm;
        private ICommand _closeCommand;
        private ICommand _saveCommand;
        private string _name;
        private string _type;
        private string _fermentability;
        private string _extractYield;
        private string _percentSolid;
        private string _description;
        private string _pricePerKg;

        public AddCarbonationViewModel(MainWindowViewModel mvm)
        {
            _mvm = mvm;
            _closeCommand = new RelayCommand(_closeCommand => CloseWindow());
            _saveCommand = new RelayCommand(_saveCommand => Save());
        }


        public void Save()
        {
            if (string.IsNullOrEmpty(Fermentability))
                Fermentability = "100";
            if (string.IsNullOrEmpty(ExtractYield))
                ExtractYield = "100";
            if (string.IsNullOrEmpty(PercentSolid))
                PercentSolid = "100";
            if (string.IsNullOrEmpty(PricePerKg))
                PricePerKg = "0";

            if (!string.IsNullOrEmpty(Name))
            {
                float carbonationFermentabilityTemp = float.Parse(Fermentability, System.Globalization.CultureInfo.InvariantCulture);
                float carbonationExtractYTemp = float.Parse(ExtractYield, System.Globalization.CultureInfo.InvariantCulture);
                float carbonationPercentSolidTemp = float.Parse(PercentSolid, System.Globalization.CultureInfo.InvariantCulture);
                float carbonationPriceTemp = float.Parse(PricePerKg, System.Globalization.CultureInfo.InvariantCulture);

                float carbonationFermentability = (float)Math.Ceiling(carbonationFermentabilityTemp * 100f) / 100f;
                float carbonationExtractY = (float)Math.Ceiling(carbonationExtractYTemp * 100f) / 100f;
                float carbonationPercentSolid = (float)Math.Ceiling(carbonationPercentSolidTemp * 100f) / 100f;
                float carbonationPrice = (float)Math.Ceiling(carbonationPriceTemp * 100f) / 100f;


                string[] newCarbonationColumns = { "Name", "Type", "Fermentability", "ExtractYield", "PercentSolid", "Description", "PricePerKg" };
                string[] newCarbonationValues = { Name, Type, carbonationFermentability.ToString(), carbonationExtractY.ToString(), carbonationPercentSolid.ToString(), Description, carbonationPrice.ToString() };
                string tableName = "Carbonation";

                _mvm.DBC.InsertIntoTable(tableName, newCarbonationColumns, newCarbonationValues);
                var id = _mvm.DBC.SelectSingleColumnOneResult(tableName, "ORDER BY Id DESC LIMIT 1", "Id");

                _mvm.DB.Carbonations.Add(new Model.DBModel.Carbonation
                {
                    Id = Int32.Parse(id),
                    Name = Name,
                    Type = Type,
                    Fermentability = carbonationFermentability,
                    ExtractYield = carbonationExtractY,
                    PercentSolid = carbonationPercentSolid,
                    Description = Description,
                    PricePerKg = carbonationPrice
                });
                _mvm.DB.SortCarbonations();

                MessageBox.Show("Dodano typ nasycenia");
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
        public string Fermentability { get { return _fermentability; } set { _fermentability = value; OnPropertyChanged("Fermentability"); } }
        public string ExtractYield { get { return _extractYield; } set { _extractYield = value; OnPropertyChanged("ExtractYield"); } }
        public string PercentSolid { get { return _percentSolid; } set { _percentSolid = value; OnPropertyChanged("PercentSolid"); } }
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
