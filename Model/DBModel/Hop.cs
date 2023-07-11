using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerMaster.Model.DBModel
{
    public class Hop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Country { get; set; }
        public float Alpha { get; set; }
        public float Beta { get; set; }
        public string Description { get; set; }
        public float PricePerGram { get; set; }
    }
}
