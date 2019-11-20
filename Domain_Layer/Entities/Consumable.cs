using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Layer.Entities
{
    public class Consumable
    {
        public int Manufacturer_Id { get; set; }
        public float? Fiber { get; set; }
        public float? Fat { get; set; }
        public float? Sugar { get; set; }
        public float? Carbs { get; set; }
        public float? Protein { get; set; }
        public int Calories { get; set; }
        public int Portion { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public int Cid { get; set; }
        Manufacturer Manufacturer { get; set; }

        public override string ToString()
        {
            return Name + " " + Category + " " + Portion + "g " + Calories + "kcal ";
        }
    }
}
