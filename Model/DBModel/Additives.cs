using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerMaster.Model.DBModel
{
    public class Additives
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Country { get; set; }
        public string Supplier { get; set; }
        public float Color { get; set; }
        public float MaxGrist { get; set; } // max procent zasypu
        public float Sugar { get; set; } // np. BLG soku
        public float Potential { get; set; } // np. corn sugar ma 42 gravity points per pound per gallon czyli ma Potential 1.042
        public float Yield { get; set; } // albo inaczej, wydajność fermentacji corn sugar ma 100%, OG ma 1.042 czyli ma 42 gravity points
        public float Bitterness { get; set; } // np w ekstrakcie nachmielonym 1.7kg Bitterness = 270 więc w warce 23 litrowej 270 x 1.7 / 23 = 20 IBU (Bitternes x kg / brew volume)
        public string Description { get; set; }
        public float PricePerL_Kg { get; set; }
    }
}
