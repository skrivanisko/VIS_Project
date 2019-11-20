using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Layer.Entities
{
    public class Measurement
    {
        public DateTime Mdate { get; set; }
        public float? Thighs { get; set; }
        public float? Chest { get; set; }
        public float? Waist { get; set; }
        public float? Fat { get; set; }
        public float Weight { get; set; }
        public int Height { get; set; }
        public int User_Id { get; set; }
        public int Mid { get; set; }
        User User { get; set; }

        public string ComputeBMI()
        {
            var heightM = (float)Height;
            float final = heightM / 100;
            float ret = Weight / (final * final);
            return ret.ToString("F");
        }
    }
}
