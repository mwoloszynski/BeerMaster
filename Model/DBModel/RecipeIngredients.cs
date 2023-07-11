using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerMaster.Model.DBModel
{
    public class RecipeIngredients
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public int IngredientId { get; set; }
        public string IngredientType { get; set; }
        public float Amount { get; set; }
        public int MashStepId { get; set; }
        public int FermentationStepId { get; set; }
        public float AddInTime { get; set; } // inny czas dodania w dniach
        public float HoldTime { get; set; } // w przypadku dodawania podczas gotowania np chmielu, czas całkowity gotowania składnika
        public string HoldTimeType { get; set; } // dzień / godzina / minuta / przy zabutelkowaniu
    }
}
