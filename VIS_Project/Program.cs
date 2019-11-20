using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Layer;
using Data_Layer.DTO;
using Data_Layer.DataMapper;
using Domain_Layer.Entities;
using System.Collections.ObjectModel;

namespace VIS_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            User u;
            u = new UsersMapper().Select(4);

            

            u.DietPlans = new DietPlanMapper().SelectUserDietPlans(u.Userid, DateTime.Parse("8.12.2018").Date);

            foreach(DietPlan dp in u.DietPlans)
            {
                Console.WriteLine(dp.Dpid);
            }




        }
    }
}
