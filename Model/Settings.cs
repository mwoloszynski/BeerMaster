using BeerMaster.Controllers;
using BeerMaster.Model.DBModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace BeerMaster.Model
{
    public class Settings
    {
        public string UserFirstName;
        public string UserLastName;
        public List<UnitSettings> UnitSettings;

        public Settings()
        {
            UnitSettings = new List<UnitSettings>();
        }

        private void SetLanguageDictionary(string lang)
        {
            ResourceDictionary dict = new ResourceDictionary();
            switch(lang)
            {
                case "en":
                    dict.Source = new Uri("..\\Resources\\Dict\\Lang_en.xaml", UriKind.Relative);
                    break;
                case "pl":
                    dict.Source = new Uri("..\\Resources\\Dict\\Lang_pl.xaml", UriKind.Relative);
                    break;
                default:
                    dict.Source = new Uri("..\\Resources\\Dict\\Lang_en.xaml", UriKind.Relative);
                    break;
            }
            Application.Current.Resources.MergedDictionaries.Add(dict);
        }

        public void LoadSettings(DBController dbc, DB db)
        {
            SetLanguageDictionary("pl");
            UserFirstName = dbc.SelectSingleColumnOneResult("UserInfo", "where Name = 'FirstName'", "Value");
            UserLastName = dbc.SelectSingleColumnOneResult("UserInfo", "where Name = 'LastName'", "Value");
            int unitSettingsCount = dbc.SelectSingleColumnMany("UnitSettings", "", "Id").Count;
            if(unitSettingsCount > 0 )
            {
                List<string> Id = dbc.SelectSingleColumnMany("UnitSettings", "", "Id");
                List<string> Name = dbc.SelectSingleColumnMany("UnitSettings", "", "Name");
                List<string> Value = dbc.SelectSingleColumnMany("UnitSettings", "", "Value");
                for(int i=0; i<unitSettingsCount; i++)
                {
                    UnitSettings.Add(new UnitSettings
                    {
                        Id = Int32.Parse(Id[i]),
                        Name = Name[i],
                        Value = Value[i]
                    });
                }
            }

            db.Additives = new ObservableCollection<Additives>();
            db.Hops = new ObservableCollection<Hop>();
            db.Yeasts = new ObservableCollection<Yeast>();
            db.Malts = new ObservableCollection<Malt>();
            db.Miscellaneous = new ObservableCollection<Miscellaneous>();
            db.Waters = new ObservableCollection<Water>();
            db.Brews = new ObservableCollection<Brew>();
            db.Carbonations = new ObservableCollection<Carbonation>();
            db.Equipments = new ObservableCollection<Equipment>();
            db.Fermentations = new ObservableCollection<Fermentation>();
            db.Mashes = new ObservableCollection<Mash>();
            db.MashSteps = new ObservableCollection<MashSteps>();
            db.Recipes = new ObservableCollection<Recipe>();
            db.RecipeIngredients = new ObservableCollection<RecipeIngredients>();
            db.Styles = new ObservableCollection<DBModel.Style>();

            int additivesCount = dbc.SelectSingleColumnMany("Additives", "", "Id").Count;
            if (additivesCount > 0)
            {
                List<string> Id = dbc.SelectSingleColumnMany("Additives", "", "Id");
                List<string> Name = dbc.SelectSingleColumnMany("Additives", "", "Name");
                List<string> Type = dbc.SelectSingleColumnMany("Additives", "", "Type");
                List<string> Country = dbc.SelectSingleColumnMany("Additives", "", "Country");
                List<string> Supplier = dbc.SelectSingleColumnMany("Additives", "", "Supplier");
                List<string> Color = dbc.SelectSingleColumnMany("Additives", "", "Color");
                List<string> MaxGrist = dbc.SelectSingleColumnMany("Additives", "", "MaxGrist");
                List<string> Sugar = dbc.SelectSingleColumnMany("Additives", "", "Sugar");
                List<string> Potential = dbc.SelectSingleColumnMany("Additives", "", "Potential");
                List<string> Yield = dbc.SelectSingleColumnMany("Additives", "", "Yield");
                List<string> Bitterness = dbc.SelectSingleColumnMany("Additives", "", "Bitterness");
                List<string> Description = dbc.SelectSingleColumnMany("Additives", "", "Description");
                List<string> PricePerL = dbc.SelectSingleColumnMany("Additives", "", "PricePerL");
                for (int i = 0; i < unitSettingsCount; i++)
                {
                    db.Additives.Add(new Additives
                    {
                        Id = Int32.Parse(Id[i]),
                        Name = Name[i],
                        Type = Type[i],
                        Country = Country[i],
                        Supplier = Supplier[i],
                        Color = float.Parse(Color[i]),
                        MaxGrist = float.Parse(MaxGrist[i]),
                        Sugar = float.Parse(Sugar[i]),
                        Potential = float.Parse(Potential[i]),
                        Yield = float.Parse(Yield[i]),
                        Bitterness = float.Parse(Bitterness[i]),
                        Description = Description[i],
                        PricePerL_Kg = float.Parse(PricePerL[i])
                    });
                }
            }

            int hopsCount = dbc.SelectSingleColumnMany("Hop", "", "Id").Count;
            if (hopsCount > 0)
            {
                List<string> Id = dbc.SelectSingleColumnMany("Hop", "", "Id");
                List<string> Name = dbc.SelectSingleColumnMany("Hop", "", "Name");
                List<string> Type = dbc.SelectSingleColumnMany("Hop", "", "Type");
                List<string> Country = dbc.SelectSingleColumnMany("Hop", "", "Country");
                List<string> Alpha = dbc.SelectSingleColumnMany("Hop", "", "Alpha");
                List<string> Beta = dbc.SelectSingleColumnMany("Hop", "", "Beta");
                List<string> Description = dbc.SelectSingleColumnMany("Hop", "", "Description");
                List<string> PricePerGram = dbc.SelectSingleColumnMany("Hop", "", "PricePerGram");
                for (int i = 0; i < hopsCount; i++)
                {
                    db.Hops.Add(new Hop
                    {
                        Id = Int32.Parse(Id[i]),
                        Name = Name[i],
                        Type = Type[i],
                        Country = Country[i],
                        Alpha = float.Parse(Alpha[i]),
                        Beta = float.Parse(Beta[i]),
                        Description = Description[i],
                        PricePerGram = float.Parse(PricePerGram[i])
                    });
                }
            }

            int yeastsCount = dbc.SelectSingleColumnMany("Yeast", "", "Id").Count;
            if (yeastsCount > 0)
            {
                List<string> Id = dbc.SelectSingleColumnMany("Yeast", "", "Id");
                List<string> Name = dbc.SelectSingleColumnMany("Yeast", "", "Name");
                List<string> BeerCategory = dbc.SelectSingleColumnMany("Yeast", "", "BeerCategory");
                List<string> Supplier = dbc.SelectSingleColumnMany("Yeast", "", "Supplier");
                List<string> Type = dbc.SelectSingleColumnMany("Yeast", "", "Type");
                List<string> DosageAmountGram = dbc.SelectSingleColumnMany("Yeast", "", "DosageAmountGram");
                List<string> DosagePerAmountLiters = dbc.SelectSingleColumnMany("Yeast", "", "DosagePerAmountLiters");
                List<string> MinTemperature = dbc.SelectSingleColumnMany("Yeast", "", "MinTemperature");
                List<string> MaxTemperature = dbc.SelectSingleColumnMany("Yeast", "", "MaxTemperature");
                List<string> Attenuation = dbc.SelectSingleColumnMany("Yeast", "", "Attenuation");
                List<string> Flocculation = dbc.SelectSingleColumnMany("Yeast", "", "Flocculation");
                List<string> Description = dbc.SelectSingleColumnMany("Yeast", "", "Description");
                List<string> PricePerPackage = dbc.SelectSingleColumnMany("Yeast", "", "PricePerPackage");
                for (int i = 0; i < yeastsCount; i++)
                {
                    db.Yeasts.Add(new Yeast
                    {
                        Id = Int32.Parse(Id[i]),
                        Name = Name[i],
                        BeerCategory = BeerCategory[i],
                        Supplier = Supplier[i],
                        Type = Type[i],
                        DosageAmountGram = float.Parse(DosageAmountGram[i]),
                        DosagePerAmountLiters = float.Parse(DosagePerAmountLiters[i]),
                        MinTemperature = float.Parse(MinTemperature[i]),
                        MaxTemperature = float.Parse(MaxTemperature[i]),
                        Attenuation = float.Parse(Attenuation[i]),
                        Flocculation = float.Parse(Flocculation[i]),
                        Description = Description[i],
                        PricePerPackage = float.Parse(PricePerPackage[i])
                    });
                }
            }

            int maltsCount = dbc.SelectSingleColumnMany("Malt", "", "Id").Count;
            if (maltsCount > 0)
            {
                List<string> Id = dbc.SelectSingleColumnMany("Malt", "", "Id");
                List<string> Name = dbc.SelectSingleColumnMany("Malt", "", "Name");
                List<string> Type = dbc.SelectSingleColumnMany("Malt", "", "Type");
                List<string> Country = dbc.SelectSingleColumnMany("Malt", "", "Country");
                List<string> Supplier = dbc.SelectSingleColumnMany("Malt", "", "Supplier");
                List<string> Color = dbc.SelectSingleColumnMany("Malt", "", "Color");
                List<string> MaxGrist = dbc.SelectSingleColumnMany("Malt", "", "MaxGrist");
                List<string> Extract = dbc.SelectSingleColumnMany("Malt", "", "Extract");
                List<string> Description = dbc.SelectSingleColumnMany("Malt", "", "Description");
                List<string> PricePerKg = dbc.SelectSingleColumnMany("Malt", "", "PricePerKg");
                for (int i = 0; i < maltsCount; i++)
                {
                    db.Malts.Add(new Malt
                    {
                        Id = Int32.Parse(Id[i]),
                        Name = Name[i],
                        Type = Type[i],
                        Country = Country[i],
                        Supplier = Supplier[i],
                        Color = float.Parse(Color[i]),
                        MaxGrist = float.Parse(MaxGrist[i]),
                        Extract = float.Parse(Extract[i]),
                        Description = Description[i],
                        PricePerKg = float.Parse(PricePerKg[i])
                    });
                }
            }

            int miscellaneousCount = dbc.SelectSingleColumnMany("Miscellaneous", "", "Id").Count;
            if (miscellaneousCount > 0)
            {
                List<string> Id = dbc.SelectSingleColumnMany("Miscellaneous", "", "Id");
                List<string> Name = dbc.SelectSingleColumnMany("Miscellaneous", "", "Name");
                List<string> Type = dbc.SelectSingleColumnMany("Miscellaneous", "", "Type");
                List<string> DosageAmount = dbc.SelectSingleColumnMany("Miscellaneous", "", "DosageAmount");
                List<string> DosagePerAmount = dbc.SelectSingleColumnMany("Miscellaneous", "", "DosagePerAmount");
                List<string> TimeOfUse = dbc.SelectSingleColumnMany("Miscellaneous", "", "TimeOfUse");
                List<string> Description = dbc.SelectSingleColumnMany("Miscellaneous", "", "Description");
                List<string> PricePerDose = dbc.SelectSingleColumnMany("Miscellaneous", "", "PricePerDose");
                for (int i = 0; i < miscellaneousCount; i++)
                {
                    db.Miscellaneous.Add(new Miscellaneous
                    {
                        Id = Int32.Parse(Id[i]),
                        Name = Name[i],
                        Type = Type[i],
                        DosageAmount = float.Parse(DosageAmount[i]),
                        DosagePerAmount = float.Parse(DosagePerAmount[i]),
                        TimeOfUse = TimeOfUse[i],
                        Description = Description[i],
                        PricePerDose = float.Parse(PricePerDose[i])
                    });
                }
            }

            int watersCount = dbc.SelectSingleColumnMany("Water", "", "Id").Count;
            if (watersCount > 0)
            {
                List<string> Id = dbc.SelectSingleColumnMany("Water", "", "Id");
                List<string> Name = dbc.SelectSingleColumnMany("Water", "", "Name");
                List<string> PH = dbc.SelectSingleColumnMany("Water", "", "PH");
                List<string> Calcium = dbc.SelectSingleColumnMany("Water", "", "Calcium");
                List<string> Magnesium = dbc.SelectSingleColumnMany("Water", "", "Magnesium");
                List<string> Sodium = dbc.SelectSingleColumnMany("Water", "", "Sodium");
                List<string> Sulfate = dbc.SelectSingleColumnMany("Water", "", "Sulfate");
                List<string> Chloride = dbc.SelectSingleColumnMany("Water", "", "Chloride");
                List<string> Bicarbonate = dbc.SelectSingleColumnMany("Water", "", "Bicarbonate");
                List<string> Description = dbc.SelectSingleColumnMany("Water", "", "Description");
                List<string> PricePerLiter = dbc.SelectSingleColumnMany("Water", "", "PricePerLiter");
                for (int i = 0; i < watersCount; i++)
                {
                    db.Waters.Add(new Water
                    {
                        Id = Int32.Parse(Id[i]),
                        Name = Name[i],
                        PH = float.Parse(PH[i]),
                        Calcium = float.Parse(Calcium[i]),
                        Magnesium = float.Parse(Magnesium[i]),
                        Sodium = float.Parse(Sodium[i]),
                        Sulfate = float.Parse(Sulfate[i]),
                        Chloride = float.Parse(Chloride[i]),
                        Bicarbonate = float.Parse(Bicarbonate[i]),
                        Description = Description[i],
                        PricePerLiter = float.Parse(PricePerLiter[i])
                    });
                }
            }

            int brewsCount = dbc.SelectSingleColumnMany("Brew", "", "Id").Count;
            if (brewsCount > 0)
            {
                List<string> Id = dbc.SelectSingleColumnMany("Brew", "", "Id");
                List<string> Name = dbc.SelectSingleColumnMany("Brew", "", "Name");
                List<string> Description = dbc.SelectSingleColumnMany("Brew", "", "Description");
                List<string> BrewDate = dbc.SelectSingleColumnMany("Brew", "", "BrewDate");
                List<string> RecipeId = dbc.SelectSingleColumnMany("Brew", "", "RecipeId");
                List<string> BottlingDate = dbc.SelectSingleColumnMany("Brew", "", "BottlingDate");
                List<string> BottlesAmount = dbc.SelectSingleColumnMany("Brew", "", "BottlesAmount");
                List<string> BottlesVolume = dbc.SelectSingleColumnMany("Brew", "", "BottlesVolume");
                List<string> Rating = dbc.SelectSingleColumnMany("Brew", "", "Rating");
                for (int i = 0; i < brewsCount; i++)
                {
                    db.Brews.Add(new Brew
                    {
                        Id = Int32.Parse(Id[i]),
                        Name = Name[i],
                        Description = Description[i],
                        BrewDate = DateTime.Parse(BrewDate[i]),
                        RecipeId = Int32.Parse(RecipeId[i]),
                        BottlingDate = DateTime.Parse(BottlingDate[i]),
                        BottlesAmount = Int32.Parse(BottlesAmount[i]),
                        BottlesVolume = float.Parse(BottlesVolume[i]),
                        Rating = float.Parse(Rating[i])
                    });
                }
            }

            int carbonationsCount = dbc.SelectSingleColumnMany("Carbonation", "", "Id").Count;
            if (carbonationsCount > 0)
            {
                List<string> Id = dbc.SelectSingleColumnMany("Carbonation", "", "Id");
                List<string> Name = dbc.SelectSingleColumnMany("Carbonation", "", "Name");
                List<string> Type = dbc.SelectSingleColumnMany("Carbonation", "", "Type");
                List<string> Fermentability = dbc.SelectSingleColumnMany("Carbonation", "", "Fermentability");
                List<string> ExtractYield = dbc.SelectSingleColumnMany("Carbonation", "", "ExtractYield");
                List<string> PercentSolid = dbc.SelectSingleColumnMany("Carbonation", "", "PercentSolid");
                List<string> Description = dbc.SelectSingleColumnMany("Carbonation", "", "Description");
                List<string> PricePerKg = dbc.SelectSingleColumnMany("Carbonation", "", "PricePerKg");
                for (int i = 0; i < carbonationsCount; i++)
                {
                    db.Carbonations.Add(new Carbonation
                    {
                        Id = Int32.Parse(Id[i]),
                        Name = Name[i],
                        Type = Type[i],
                        Fermentability = float.Parse(Fermentability[i]),
                        ExtractYield = float.Parse(ExtractYield[i]),
                        PercentSolid = float.Parse(PercentSolid[i]),
                        Description = Description[i],
                        PricePerKg = float.Parse(PricePerKg[i])
                    });
                }
            }

            int equipmentsCount = dbc.SelectSingleColumnMany("Equipment", "", "Id").Count;
            if (equipmentsCount > 0)
            {
                List<string> Id = dbc.SelectSingleColumnMany("Equipment", "", "Id");
                List<string> Name = dbc.SelectSingleColumnMany("Equipment", "", "Name");
                List<string> Type = dbc.SelectSingleColumnMany("Equipment", "", "Type");
                List<string> BatchVolume = dbc.SelectSingleColumnMany("Equipment", "", "BatchVolume");
                List<string> Efficiency = dbc.SelectSingleColumnMany("Equipment", "", "Efficiency");
                List<string> Description = dbc.SelectSingleColumnMany("Equipment", "", "Description");
                for (int i = 0; i < equipmentsCount; i++)
                {
                    db.Equipments.Add(new Equipment
                    {
                        Id = Int32.Parse(Id[i]),
                        Name = Name[i],
                        Type = Type[i],
                        BatchVolume = float.Parse(BatchVolume[i]),
                        Efficiency = float.Parse(Efficiency[i]),
                        Description = Description[i]
                    });
                }
            }

            int fermentationsCount = dbc.SelectSingleColumnMany("Fermentation", "", "Id").Count;
            if (fermentationsCount > 0)
            {
                List<string> Id = dbc.SelectSingleColumnMany("Fermentation", "", "Id");
                List<string> Name = dbc.SelectSingleColumnMany("Fermentation", "", "Name");
                List<string> TurboFermentationDescription = dbc.SelectSingleColumnMany("Fermentation", "", "TurboFermentationDescription");
                List<string> TurboFermentationTime = dbc.SelectSingleColumnMany("Fermentation", "", "TurboFermentationTime");
                List<string> MinTurboFermentationTemp = dbc.SelectSingleColumnMany("Fermentation", "", "MinTurboFermentationTemp");
                List<string> MaxTurboFermentationTemp = dbc.SelectSingleColumnMany("Fermentation", "", "MaxTurboFermentationTemp");
                List<string> SilentFermentationDescription = dbc.SelectSingleColumnMany("Fermentation", "", "SilentFermentationDescription");
                List<string> SilentFermentationTime = dbc.SelectSingleColumnMany("Fermentation", "", "SilentFermentationTime");
                List<string> MinSilentFermentationTemp = dbc.SelectSingleColumnMany("Fermentation", "", "MinSilentFermentationTemp");
                List<string> MaxSilentFermentationTemp = dbc.SelectSingleColumnMany("Fermentation", "", "MaxSilentFermentationTemp");
                List<string> LageringDescription = dbc.SelectSingleColumnMany("Fermentation", "", "LageringDescription");
                List<string> LageringTime = dbc.SelectSingleColumnMany("Fermentation", "", "LageringTime");
                List<string> MinLageringTemp = dbc.SelectSingleColumnMany("Fermentation", "", "MinLageringTemp");
                List<string> MaxLageringTemp = dbc.SelectSingleColumnMany("Fermentation", "", "MaxLageringTemp");
                List<string> AgingDescription = dbc.SelectSingleColumnMany("Fermentation", "", "AgingDescription");
                List<string> AgingTime = dbc.SelectSingleColumnMany("Fermentation", "", "AgingTime");
                List<string> MinAgingTemp = dbc.SelectSingleColumnMany("Fermentation", "", "MinAgingTemp");
                List<string> MaxAgingTemp = dbc.SelectSingleColumnMany("Fermentation", "", "MaxAgingTemp");
                List<string> Description = dbc.SelectSingleColumnMany("Fermentation", "", "Description");
                for (int i = 0; i < fermentationsCount; i++)
                {
                    db.Fermentations.Add(new Fermentation
                    {
                        Id = Int32.Parse(Id[i]),
                        Name = Name[i],
                        TurboFermentationDescription = TurboFermentationDescription[i],
                        TurboFermentationTime = Int32.Parse(TurboFermentationTime[i]),
                        MinTurboFermentationTemp = float.Parse(MinTurboFermentationTemp[i]),
                        MaxTurboFermentationTemp = float.Parse(MaxTurboFermentationTemp[i]),
                        SilentFermentationDescription = SilentFermentationDescription[i],
                        SilentFermentationTime = Int32.Parse(SilentFermentationTime[i]),
                        MinSilentFermentationTemp = float.Parse(MinSilentFermentationTemp[i]),
                        MaxSilentFermentationTemp = float.Parse(MaxSilentFermentationTemp[i]),
                        LageringDescription = LageringDescription[i],
                        LageringTime = Int32.Parse(LageringTime[i]),
                        MinLageringTemp = float.Parse(MinLageringTemp[i]),
                        MaxLageringTemp = float.Parse(MaxLageringTemp[i]),
                        AgingDescription = AgingDescription[i],
                        AgingTime = Int32.Parse(AgingTime[i]),
                        MinAgingTemp = float.Parse(MinAgingTemp[i]),
                        MaxAgingTemp = float.Parse(MaxAgingTemp[i]),
                        Description = Description[i]
                    });
                }
            }

            int mashesCount = dbc.SelectSingleColumnMany("Mash", "", "Id").Count;
            if (mashesCount > 0)
            {
                List<string> Id = dbc.SelectSingleColumnMany("Mash", "", "Id");
                List<string> Name = dbc.SelectSingleColumnMany("Mash", "", "Name");
                List<string> Type = dbc.SelectSingleColumnMany("Mash", "", "Type");
                List<string> Description = dbc.SelectSingleColumnMany("Mash", "", "Description");
                for (int i = 0; i < mashesCount; i++)
                {
                    db.Mashes.Add(new Mash
                    {
                        Id = Int32.Parse(Id[i]),
                        Name = Name[i],
                        Type = Type[i],
                        Description = Description[i]
                    });
                }
            }

            int mashStepsCount = dbc.SelectSingleColumnMany("MashSteps", "", "Id").Count;
            if (mashStepsCount > 0)
            {
                List<string> Id = dbc.SelectSingleColumnMany("MashSteps", "", "Id");
                List<string> MashId = dbc.SelectSingleColumnMany("MashSteps", "", "MashId");
                List<string> Name = dbc.SelectSingleColumnMany("MashSteps", "", "Name");
                List<string> Type = dbc.SelectSingleColumnMany("MashSteps", "", "Type");
                List<string> WaterAdd = dbc.SelectSingleColumnMany("MashSteps", "", "WaterAdd");
                List<string> WaterMaltRatio = dbc.SelectSingleColumnMany("MashSteps", "", "WaterMaltRatio");
                List<string> ObtainTemperature = dbc.SelectSingleColumnMany("MashSteps", "", "ObtainTemperature");
                List<string> MaintainTemperature = dbc.SelectSingleColumnMany("MashSteps", "", "MaintainTemperature");
                List<string> StepTime = dbc.SelectSingleColumnMany("MashSteps", "", "StepTime");
                List<string> Description = dbc.SelectSingleColumnMany("MashSteps", "", "Description");
                for (int i = 0; i < mashStepsCount; i++)
                {
                    db.MashSteps.Add(new MashSteps
                    {
                        Id = Int32.Parse(Id[i]),
                        MashId = Int32.Parse(MashId[i]),
                        Name = Name[i],
                        Type = Type[i],
                        WaterAdd = float.Parse(WaterAdd[i]),
                        WaterMaltRatio = float.Parse(WaterMaltRatio[i]),
                        ObtainTemperature = float.Parse(ObtainTemperature[i]),
                        MaintainTemperature = float.Parse(MaintainTemperature[i]),
                        StepTime = float.Parse(StepTime[i]),
                        Description = Description[i]
                    });
                }
            }

            int recipesCount = dbc.SelectSingleColumnMany("Recipe", "", "Id").Count;
            if (recipesCount > 0)
            {
                List<string> Id = dbc.SelectSingleColumnMany("Recipe", "", "Id");
                List<string> Name = dbc.SelectSingleColumnMany("Recipe", "", "Name");
                List<string> BatchSize = dbc.SelectSingleColumnMany("Recipe", "", "BatchSize");
                List<string> BoilSize = dbc.SelectSingleColumnMany("Recipe", "", "BoilSize");
                List<string> StyleId = dbc.SelectSingleColumnMany("Recipe", "", "StyleId");
                List<string> EquipmentId = dbc.SelectSingleColumnMany("Recipe", "", "EquipmentId");
                List<string> MashId = dbc.SelectSingleColumnMany("Recipe", "", "MashId");
                List<string> FermentationId = dbc.SelectSingleColumnMany("Recipe", "", "FermentationId");
                List<string> CarbonationId = dbc.SelectSingleColumnMany("Recipe", "", "CarbonationId");
                List<string> CarbonationAmount = dbc.SelectSingleColumnMany("Recipe", "", "CarbonationAmount");
                List<string> Color = dbc.SelectSingleColumnMany("Recipe", "", "Color");
                List<string> Bitterness = dbc.SelectSingleColumnMany("Recipe", "", "Bitterness");
                List<string> OriginalGravity = dbc.SelectSingleColumnMany("Recipe", "", "OriginalGravity");
                List<string> FinalGravity = dbc.SelectSingleColumnMany("Recipe", "", "FinalGravity");
                List<string> Alcohol = dbc.SelectSingleColumnMany("Recipe", "", "Alcohol");
                List<string> Rating = dbc.SelectSingleColumnMany("Recipe", "", "Rating");
                for (int i = 0; i < recipesCount; i++)
                {
                    db.Recipes.Add(new Recipe
                    {
                        Id = Int32.Parse(Id[i]),
                        Name = Name[i],
                        BatchSize = float.Parse(BatchSize[i]),
                        BoilSize = float.Parse(BoilSize[i]),
                        StyleId = Int32.Parse(StyleId[i]),
                        EquipmentId = Int32.Parse(EquipmentId[i]),
                        MashId = Int32.Parse(MashId[i]),
                        FermentationId = Int32.Parse(FermentationId[i]),
                        CarbonationId = Int32.Parse(CarbonationId[i]),
                        CarbonationAmount = float.Parse(CarbonationAmount[i]),
                        Color = float.Parse(Color[i]),
                        Bitterness = float.Parse(Bitterness[i]),
                        OriginalGravity = float.Parse(OriginalGravity[i]),
                        FinalGravity = float.Parse(FinalGravity[i]),
                        Alcohol = float.Parse(Alcohol[i]),
                        Rating = float.Parse(Rating[i])
                    });
                }
            }

            int recipeIngredientsCount = dbc.SelectSingleColumnMany("RecipeIngredients", "", "Id").Count;
            if (recipeIngredientsCount > 0)
            {
                List<string> Id = dbc.SelectSingleColumnMany("RecipeIngredients", "", "Id");
                List<string> RecipeId = dbc.SelectSingleColumnMany("RecipeIngredients", "", "RecipeId");
                List<string> IngredientId = dbc.SelectSingleColumnMany("RecipeIngredients", "", "IngredientId");
                List<string> IngredientType = dbc.SelectSingleColumnMany("RecipeIngredients", "", "IngredientType");
                List<string> Amount = dbc.SelectSingleColumnMany("RecipeIngredients", "", "Amount");
                List<string> MashStepId = dbc.SelectSingleColumnMany("RecipeIngredients", "", "MashStepId");
                List<string> FermentationStepId = dbc.SelectSingleColumnMany("RecipeIngredients", "", "FermentationStepId");
                List<string> AddInTime = dbc.SelectSingleColumnMany("RecipeIngredients", "", "AddInTime");
                List<string> HoldTime = dbc.SelectSingleColumnMany("RecipeIngredients", "", "HoldTime");
                List<string> HoldTimeType = dbc.SelectSingleColumnMany("RecipeIngredients", "", "HoldTimeType");
                for (int i = 0; i < recipeIngredientsCount; i++)
                {
                    db.RecipeIngredients.Add(new RecipeIngredients
                    {
                        Id = Int32.Parse(Id[i]),
                        RecipeId = Int32.Parse(RecipeId[i]),
                        IngredientId = Int32.Parse(IngredientId[i]),
                        IngredientType = IngredientType[i],
                        Amount = float.Parse(Amount[i]),
                        MashStepId = Int32.Parse(MashStepId[i]),
                        FermentationStepId = Int32.Parse(FermentationStepId[i]),
                        AddInTime = float.Parse(AddInTime[i]),
                        HoldTime = float.Parse(HoldTime[i]),
                        HoldTimeType = HoldTimeType[i]
                    });
                }
            }

            int stylesCount = dbc.SelectSingleColumnMany("Style", "", "Id").Count;
            if (stylesCount > 0)
            {
                List<string> Id = dbc.SelectSingleColumnMany("Style", "", "Id");
                List<string> Code = dbc.SelectSingleColumnMany("Style", "", "Code");
                List<string> Name = dbc.SelectSingleColumnMany("Style", "", "Name");
                List<string> Type = dbc.SelectSingleColumnMany("Style", "", "Type");
                List<string> MinOriginalGravity = dbc.SelectSingleColumnMany("Style", "", "MinOriginalGravity");
                List<string> MaxOriginalGravity = dbc.SelectSingleColumnMany("Style", "", "MaxOriginalGravity");
                List<string> MinFinalGravity = dbc.SelectSingleColumnMany("Style", "", "MinFinalGravity");
                List<string> MaxFinalGravity = dbc.SelectSingleColumnMany("Style", "", "MaxFinalGravity");
                List<string> MinAlcohol = dbc.SelectSingleColumnMany("Style", "", "MinAlcohol");
                List<string> MaxAlcohol = dbc.SelectSingleColumnMany("Style", "", "MaxAlcohol");
                List<string> MinIBU = dbc.SelectSingleColumnMany("Style", "", "MinIBU");
                List<string> MaxIBU = dbc.SelectSingleColumnMany("Style", "", "MaxIBU");
                List<string> MinColor = dbc.SelectSingleColumnMany("Style", "", "MinColor");
                List<string> MaxColor = dbc.SelectSingleColumnMany("Style", "", "MaxColor");
                List<string> MinCarbonation = dbc.SelectSingleColumnMany("Style", "", "MinCarbonation");
                List<string> MaxCarbonation = dbc.SelectSingleColumnMany("Style", "", "MaxCarbonation");
                List<string> Description = dbc.SelectSingleColumnMany("Style", "", "Description");
                List<string> Features = dbc.SelectSingleColumnMany("Style", "", "Features");
                List<string> Appearance = dbc.SelectSingleColumnMany("Style", "", "Appearance");
                List<string> Aroma = dbc.SelectSingleColumnMany("Style", "", "Aroma");
                List<string> Taste = dbc.SelectSingleColumnMany("Style", "", "Taste");
                List<string> Ingredients = dbc.SelectSingleColumnMany("Style", "", "Ingredients");
                for (int i = 0; i < stylesCount; i++)
                {
                    db.Styles.Add(new DBModel.Style
                    {
                        Id = Int32.Parse(Id[i]),
                        Code = Code[i],
                        Name = Name[i],
                        Type = Type[i],
                        MinOriginalGravity = float.Parse(MinOriginalGravity[i]),
                        MaxOriginalGravity = float.Parse(MaxOriginalGravity[i]),
                        MinFinalGravity = float.Parse(MinFinalGravity[i]),
                        MaxFinalGravity = float.Parse(MaxFinalGravity[i]),
                        MinAlcohol = float.Parse(MinAlcohol[i]),
                        MaxAlcohol = float.Parse(MaxAlcohol[i]),
                        MinIBU = float.Parse(MinIBU[i]),
                        MaxIBU = float.Parse(MaxIBU[i]),
                        MinColor = float.Parse(MinColor[i]),
                        MaxColor = float.Parse(MaxColor[i]),
                        MinCarbonation = float.Parse(MinCarbonation[i]),
                        MaxCarbonation = float.Parse(MaxCarbonation[i]),
                        Description = Description[i],
                        Features = Features[i],
                        Appearance = Appearance[i],
                        Aroma = Aroma[i],
                        Taste = Taste[i],
                        Ingredients = Ingredients[i]
                    });
                }
            }

            db.SortMalts();
            db.SortMiscellaneous();
            db.SortHops();
            db.SortAdditives();
            db.SortYeasts();
            db.SortWaters();
            db.SortCarbonations();

            Thread.Sleep(1000);
        }
    }
}
