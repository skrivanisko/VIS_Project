using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Layer.Entities
{
    public class DietPlan
    {
        public DateTime Dpdate { get; set; }
        public int Category { get; set; }
        public float Amount { get; set; }
        public int Consumables_Id { get; set; }
        public int User_Id { get; set; }
        public int Dpid { get; set; }
        public User User { get; set; }
        public Consumable Consumable { get; set; }
        public string Showcase
        {
            get
            {
                string cat;

                if (Category == 1)
                    cat = "    SNÍDANĚ    ";
                else if (Category == 2)
                    cat = "    SVAČINA    ";
                else if (Category == 3)
                    cat = "    LUNCH    ";
                else cat = "    VEČEŘE    ";

                return Consumable.Name + "  " + Amount.ToString() + "X" + Consumable.Portion + "g  " + cat + (Amount * Consumable.Calories).ToString("f") + "Kcal";
            }
        }
        public override string ToString()
        {
            string cat;

            if (Category == 1)
                cat = "    SNÍDANĚ    ";
            else if (Category == 2)
                cat = "    SVAČINA    ";
            else if (Category == 3)
                cat = "    LUNCH    ";
            else cat = "    VEČEŘE    ";

            return Consumable.Name + "  " + Amount.ToString() + "X" + Consumable.Portion + "g  " + cat + (Amount*Consumable.Calories).ToString("f") + "Kcal";
        }
    }
}
