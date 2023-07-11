using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerMaster.Model.DBModel
{
    public class Fermentation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TurboFermentationDescription { get; set; } // Turbulent Fermentation
        public int TurboFermentationTime { get; set; } // in days
        public float MinTurboFermentationTemp { get; set; }
        public float MaxTurboFermentationTemp { get; set; }
        public string SilentFermentationDescription { get; set; } 
        public int SilentFermentationTime { get; set; } // in days
        public float MinSilentFermentationTemp { get; set; }
        public float MaxSilentFermentationTemp { get; set; }
        public string LageringDescription { get; set; }
        public int LageringTime { get; set; } // in days
        public float MinLageringTemp { get; set; }
        public float MaxLageringTemp { get; set; }
        public string AgingDescription { get; set; }
        public int AgingTime { get; set; } // in days
        public float MinAgingTemp { get; set; }
        public float MaxAgingTemp { get; set; }
        public string Description { get; set; }
    }
}
