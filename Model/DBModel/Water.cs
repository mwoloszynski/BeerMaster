using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerMaster.Model.DBModel
{
    public class Water
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public float PH { get; set; }
        public float Calcium { get; set; } // jednostka czy mg/dm^3 czy ppm - parts per milion czyli liczba gramów substancji w 1 000 000 gramów substancji czyli w wodzie mg/l bo 1 ml wody to 1 mg
        public float Magnesium { get; set; }
        public float Sodium { get; set; }
        public float Sulfate { get; set; }
        public float Chloride { get; set; }
        public float Bicarbonate { get; set; }
        public string Description { get; set; }
        public float PricePerLiter { get; set; }

    }
}
