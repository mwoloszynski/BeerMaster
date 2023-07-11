using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerMaster.Model.DBModel
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float BatchSize { get; set; } // ilość gotowego piwa do fermentora
        public float BoilSize { get; set; } // ilość piwa po filtracji do gotowania
        public int StyleId { get; set; }
        public int EquipmentId { get; set; }
        public int MashId { get; set; }
        public int FermentationId { get; set; }
        public int CarbonationId { get; set; }
        public float CarbonationAmount { get; set; }
        public float Color { get; set; }
        public float Bitterness { get; set; } // w IBU
        public float OriginalGravity { get; set; } // ekstrakt w Plato
        public float FinalGravity { get; set; } // po zakończeniu fermentacji
        public float Alcohol { get; set; } // ABV
        public float Rating { get; set; } // Ocena w skali procentowej 0-100%

    }
}
