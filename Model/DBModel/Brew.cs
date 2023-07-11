using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerMaster.Model.DBModel
{
    public class Brew
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime BrewDate { get; set; }
        public int RecipeId { get; set; }
        public DateTime BottlingDate { get; set; }
        public int BottlesAmount { get; set; }
        public float BottlesVolume { get; set; }
        public float Rating { get; set; } // Ocena warki w skali 0-100%
    }
}
