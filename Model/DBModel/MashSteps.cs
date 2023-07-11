using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerMaster.Model.DBModel
{
    public class MashSteps
    {
        public int Id { get; set; }
        public int MashId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public float WaterAdd { get; set; }
        public float WaterMaltRatio { get; set; } // L/KG
        public float ObtainTemperature { get; set; }
        public float MaintainTemperature { get; set; }
        public float StepTime { get; set; }
        public string Description { get; set; }
    }
}
