using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerMaster.Model.DBModel
{
    public class Yeast
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BeerCategory { get; set; }
        public string Supplier { get; set; }
        public string Type { get; set; }
        public float DosageAmountGram { get; set; }
        public float DosagePerAmountLiters { get; set; }
        public float MinTemperature { get; set; }
        public float MaxTemperature { get; set; }
        public float Attenuation { get; set; }
        public float Flocculation { get; set; }
        public string Description { get; set; }
        public float PricePerPackage { get; set; }
    }
}
