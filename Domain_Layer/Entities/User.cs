using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Layer.Entities
{
    public class User
    {
        public int Userid { get; set;}
        public DateTime Birthday { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Login { get; set; }
        public int Admin { get; set; }

        public Collection<Measurement> Measurements { get; set; } //plans will be inicialised when worked with and only day by day
        public Collection<DietPlan> DietPlans { get; set; }
        public Collection<WorkoutPlan> WorkoutPlans { get; set; }

        public User()
        {

        } // neměl bych mít ještě nějakou třídu, ze které bych bral data?

        public string GetBMI()
        {
            if (Measurements.Count == 0)
                return "Záznam nenalezen";
            else return Measurements.Last().ComputeBMI();
        }

        public string GetActivityNumber()
        {
            int number = Measurements.Count() + DietPlans.Count() + WorkoutPlans.Count();

            if(number != 0)
            return Login + " " + number.ToString();
            else return Login + " " + "NEAKTIVNI";

            

        }

        public string UserMakros()
        {
            float? calories = 0, fat = 0, carbs = 0, sugars = 0, protein = 0, fiber = 0;

            foreach (DietPlan dp in DietPlans)
            {

                if (dp.Consumable.Fat == null)
                    dp.Consumable.Fat = 0;
                if (dp.Consumable.Carbs == null)
                    dp.Consumable.Carbs = 0;
                if (dp.Consumable.Sugar == null)
                    dp.Consumable.Sugar = 0;
                if (dp.Consumable.Protein == null)
                    dp.Consumable.Protein = 0;
                if (dp.Consumable.Fiber == null)
                    dp.Consumable.Fiber = 0;

                
                    calories += dp.Consumable.Calories* dp.Amount;
                    fat += dp.Consumable.Fat * dp.Amount;
                    carbs += dp.Consumable.Carbs* dp.Amount;
                    sugars += dp.Consumable.Sugar* dp.Amount;
                    protein += dp.Consumable.Protein* dp.Amount;
                    fiber += dp.Consumable.Fiber * dp.Amount;
                
            }
            return ("Kalorie: " + (int)calories + " Tuk: " + (int)fat + " Sacharidy " + (int)carbs + System.Environment.NewLine + "Z toho cukry: " + (int)sugars + " Bílkoviny: " + (int)protein + " Vláknina: " + (int)fiber);
        }

        public string UserMakrosPercentage()
        {
            float? calories = 0, fat = 0, carbs = 0, sugars = 0, protein = 0, fiber = 0;

            foreach (DietPlan dp in DietPlans)
            {

                if (dp.Consumable.Fat == null)
                    dp.Consumable.Fat = 0;
                if (dp.Consumable.Carbs == null)
                    dp.Consumable.Carbs = 0;
                if (dp.Consumable.Sugar == null)
                    dp.Consumable.Sugar = 0;
                if (dp.Consumable.Protein == null)
                    dp.Consumable.Protein = 0;
                if (dp.Consumable.Fiber == null)
                    dp.Consumable.Fiber = 0;


                calories += dp.Consumable.Calories * dp.Amount;
                fat += dp.Consumable.Fat * dp.Amount;
                carbs += dp.Consumable.Carbs * dp.Amount;
                sugars += dp.Consumable.Sugar * dp.Amount;
                protein += dp.Consumable.Protein * dp.Amount;
                fiber += dp.Consumable.Fiber * dp.Amount;

            }
            
            return ("Kalorie: 100% " + calories + " Tuk: " + (fat*9/calories*100)?.ToString("n2") + "% " + " Sacharidy " + (carbs*4/calories*100)?.ToString("n2") + "% " + System.Environment.NewLine + "Z toho cukry: " + (sugars*4/calories*100)?.ToString("n2") + "% " + " Bílkoviny: " + (protein*4/calories*100)?.ToString("n2") + "% " + " Vláknina: " + (fiber*4/calories*100)?.ToString("n2") + "%");
        }

    }
}
