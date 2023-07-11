using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerMaster.Model.DBModel
{
    public class Equipment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public float BatchVolume { get; set; }
        public float Efficiency { get; set; } // Brewing Efficiency
        public string Description { get; set; }
    }
}
