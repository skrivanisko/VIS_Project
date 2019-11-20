using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Layer.Entities
{
    public class Activity
    {
        public int? Calories { get; set; }
        public float Duration { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public int Aid { get; set; }
    }
}
