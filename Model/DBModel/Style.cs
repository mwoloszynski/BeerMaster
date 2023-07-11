using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerMaster.Model.DBModel
{
    public class Style
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public float MinOriginalGravity { get; set; } // jako ekstrakt w stopniach plato
        public float MaxOriginalGravity { get; set; }
        public float MinFinalGravity { get; set; }
        public float MaxFinalGravity { get; set; }
        public float MinAlcohol { get; set; }
        public float MaxAlcohol { get; set; }
        public float MinIBU { get; set; }
        public float MaxIBU { get; set; }
        public float MinColor { get; set; } // w EBC
        public float MaxColor { get; set; }
        public float MinCarbonation { get; set; }
        public float MaxCarbonation { get; set; }
        public string Description { get; set; }
        public string Features { get; set; }
        public string Appearance { get; set; }
        public string Aroma { get; set; }
        public string Taste { get; set; }
        public string Ingredients { get; set; }
    }
}
