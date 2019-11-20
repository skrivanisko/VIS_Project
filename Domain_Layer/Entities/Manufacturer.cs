using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Layer.Entities
{
    public class Manufacturer
    {
        public int Manid { get; set; }
        public string Name { get; set; }
        public Collection<Consumable> Consumables { get; set; }
    }
}
