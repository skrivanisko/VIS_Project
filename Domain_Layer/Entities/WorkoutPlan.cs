using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Layer.Entities
{
    public class WorkoutPlan
    {
        public DateTime Wpdate { get; set; }
        public float Amount { get; set; }
        public int Activities_Id { get; set; }
        public int User_Id { get; set; }
        public int Wpid { get; set; }
        public User User { get; set; }
        public Activity Activity { get; set; }
    }
}
