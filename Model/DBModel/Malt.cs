using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerMaster.Model.DBModel
{
    public class Malt
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Country { get; set; }
        public string Supplier { get; set; }
        public float Color { get; set; }
        public float MaxGrist { get; set; }
        public float Extract { get; set; }
        public string Description { get; set; }
        public float PricePerKg { get; set; }
    }
}
