using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerMaster.Model.DBModel
{
    public class Carbonation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public float Fermentability { get; set; }
        public float ExtractYield { get; set; } // ppg
        public float PercentSolid { get; set; }
        public string Description { get; set; }
        public float PricePerKg { get; set; }
    }
}
