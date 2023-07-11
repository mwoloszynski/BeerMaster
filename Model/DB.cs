using BeerMaster.Model.DBModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerMaster.Model
{
    public class DB
    {
        public ObservableCollection<Additives> Additives { get; set; }
        public ObservableCollection<Hop> Hops { get; set; }
        public ObservableCollection<Malt> Malts { get; set; }
        public ObservableCollection<Miscellaneous> Miscellaneous { get; set; }
        public ObservableCollection<Water> Waters { get; set; }
        public ObservableCollection<Yeast> Yeasts { get; set; }
        public ObservableCollection<Brew> Brews { get; set; }
        public ObservableCollection<Carbonation> Carbonations { get; set; }
        public ObservableCollection<Equipment> Equipments { get; set; }
        public ObservableCollection<Fermentation> Fermentations { get; set; }
        public ObservableCollection<Mash> Mashes { get; set; }
        public ObservableCollection<MashSteps> MashSteps { get; set; }
        public ObservableCollection<Recipe> Recipes { get; set; }
        public ObservableCollection<RecipeIngredients> RecipeIngredients { get; set; }
        public ObservableCollection<Style> Styles { get; set; }

        public void SortMalts()
        {
            Malts = new ObservableCollection<Malt>(Malts.OrderBy(x => x.Name));
        }

        public void SortYeasts()
        {
            Yeasts = new ObservableCollection<Yeast>(Yeasts.OrderBy(x => x.Name));
        }

        public void SortWaters()
        {
            Waters = new ObservableCollection<Water>(Waters.OrderBy(x => x.Name));
        }

        public void SortMiscellaneous()
        {
            Miscellaneous = new ObservableCollection<Miscellaneous>(Miscellaneous.OrderBy(x => x.Name));
        }

        public void SortAdditives()
        {
            Additives = new ObservableCollection<Additives>(Additives.OrderBy(x => x.Name));
        }

        public void SortHops()
        {
            Hops = new ObservableCollection<Hop>(Hops.OrderBy(x => x.Name));
        }

        public void SortCarbonations()
        {
            Carbonations = new ObservableCollection<Carbonation>(Carbonations.OrderBy(x => x.Name));
        }

    }
}
