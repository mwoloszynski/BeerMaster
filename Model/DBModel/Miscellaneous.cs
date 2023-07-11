using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerMaster.Model.DBModel
{
    public class Miscellaneous
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public float DosageAmount { get; set; }
        public float DosagePerAmount { get; set; }
        public string TimeOfUse { get; set; }
        public string Description { get; set; }
        public float PricePerDose { get; set; }
    }
}
