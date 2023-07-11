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
using BeerMaster.Model.DBModel;

namespace BeerMaster.ViewModel
{
    public class AddMiscellaneousViewModel : ViewModelBase, ICloseWindow
    {
        private MainWindowViewModel _mvm;
        private ICommand _closeCommand;
        private ICommand _saveCommand;
        private string _name;
        private string _type;
        private string _dosageAmount;
        private string _dosagePerAmount;
        private string _timeOfUse;
        private string _description;
        private string _pricePerDose;

        public AddMiscellaneousViewModel(MainWindowViewModel mvm)
        {
            _mvm = mvm;
            _closeCommand = new RelayCommand(_closeCommand => CloseWindow());
            _saveCommand = new RelayCommand(_saveCommand => Save());
        }

        public void Save()
        {
            if (string.IsNullOrEmpty(DosageAmount))
                DosageAmount = "0";
            if (string.IsNullOrEmpty(DosagePerAmount))
                DosagePerAmount = "0";
            if (string.IsNullOrEmpty(PricePerDose))
                PricePerDose = "0";
            if (!string.IsNullOrEmpty(Name))
            {
                float miscDosageTemp = float.Parse(DosageAmount, System.Globalization.CultureInfo.InvariantCulture);
                float miscDosagePerAmountTemp = float.Parse(DosagePerAmount, System.Globalization.CultureInfo.InvariantCulture);
                float miscPriceTemp = float.Parse(PricePerDose, System.Globalization.CultureInfo.InvariantCulture);

                float miscDosage = (float)Math.Ceiling(miscDosageTemp * 100f) / 100f;
                float miscDosagePerAmount = (float)Math.Ceiling(miscDosagePerAmountTemp * 100f) / 100f;
                float miscPrice = (float)Math.Ceiling(miscPriceTemp * 100f) / 100f;

                string[] newMiscColumns = { "Name", "Type", "DosageAmount", "DosagePerAmount", "TimeOfUse", "Description", "PricePerDose" };
                string[] newMiscValues = { Name, Type, miscDosage.ToString(), miscDosagePerAmount.ToString(), TimeOfUse, Description, miscPrice.ToString() };
                string tableName = "Miscellaneous";

                _mvm.DBC.InsertIntoTable(tableName, newMiscColumns, newMiscValues);
                var id = _mvm.DBC.SelectSingleColumnOneResult(tableName, "ORDER BY Id DESC LIMIT 1", "Id");

                _mvm.DB.Miscellaneous.Add(new Model.DBModel.Miscellaneous
                {
                    Id = Int32.Parse(id),
                    Name = Name,
                    Type = Type,
                    DosageAmount = miscDosage,
                    DosagePerAmount = miscDosagePerAmount,
                    TimeOfUse = TimeOfUse,
                    Description = Description,
                    PricePerDose = miscPrice
                });
                _mvm.DB.SortMiscellaneous();

                MessageBox.Show("Dodano inny składnik");
                CloseWindow();
            }
            else
            {
                // Obsługa błędów;
            }
        }


        public string Name { get { return _name; } set { _name = value; OnPropertyChanged("Name"); } }
        public string Type { get { return _type; } set { _type = value; OnPropertyChanged("Type"); } }
        public string DosageAmount { get { return _dosageAmount; } set { _dosageAmount = value; OnPropertyChanged("DosageAmount"); } }
        public string DosagePerAmount { get { return _dosagePerAmount; } set { _dosagePerAmount = value; OnPropertyChanged("DosagePerAmount"); } }
        public string TimeOfUse { get { return _timeOfUse; } set { _timeOfUse = value; OnPropertyChanged("TimeOfUse"); } }
        public string Description { get { return _description; } set { _description = value; OnPropertyChanged("Description"); } }
        public string PricePerDose { get { return _pricePerDose; } set { _pricePerDose = value; OnPropertyChanged("PricePerDose"); } }

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
