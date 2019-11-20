using Domain_Layer.Entities;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer.DataMapper
{
    public class DietPlanMapper : IDataMapper<DietPlan>
    {
        public static String SQL_SELECT = "SELECT * FROM DietPlan";
        public static String SQL_SELECT_ID = "SELECT * FROM DietPlan WHERE dpid=:id";
        public static String SQL_INSERT = "INSERT INTO DietPlan"
            + " VALUES (:id, :user_id, :consumable, :amount, :category, :datet)";
        public static String SQL_DELETE_ID = "DELETE FROM DietPlan WHERE dpid=:id";
        public static String SQL_MAX_ID = "SELECT MAX(dpid) FROM DietPlan";
        public static String SQL_UPDATE = "UPDATE DietPlan SET User_id=:user_id, Consumables_id=:consumable, amount=:amount, category=:category, dpdate=:datet WHERE dpid=:id";

        private static void PrepareCommand(OracleCommand command, DietPlan plan)
        {

            command.BindByName = true;
            command.Parameters.AddWithValue(":id", plan.Dpid);
            command.Parameters.AddWithValue(":user_id", plan.User_Id);
            command.Parameters.AddWithValue(":consumable", plan.Consumables_Id);
            command.Parameters.AddWithValue(":amount", plan.Amount);
            command.Parameters.AddWithValue(":category", plan.Category);
            command.Parameters.AddWithValue(":datet", plan.Dpdate);
        }
        private static Collection<DietPlan> Read(OracleDataReader reader)
        {
            Collection<DietPlan> Diet_Plans = new Collection<DietPlan>();

            while (reader.Read())
            {
                int i = -1;
                DietPlan plan = new DietPlan();
                plan.Dpid = reader.GetInt32(++i);
                plan.User_Id = reader.GetInt32(++i);
                plan.Consumables_Id = reader.GetInt32(++i);
                plan.Amount = reader.GetFloat(++i);
                plan.Category = reader.GetInt32(++i);
                plan.Dpdate = reader.GetDateTime(++i);

                Diet_Plans.Add(plan);
            }
            return Diet_Plans;
        }
        public int Update(DietPlan plan)
        {
            Database.GetInstance().Connect();
            OracleCommand command = Database.GetInstance().CreateCommand(SQL_UPDATE);
            PrepareCommand(command, plan);
            int ret = Database.GetInstance().ExecuteNonQuery(command);
            Database.GetInstance().Close();
            return ret;
        }
        public int Insert(DietPlan plan)
        {
            Database.GetInstance().Connect();
            OracleCommand command = Database.GetInstance().CreateCommand(SQL_INSERT);
            PrepareCommand(command, plan);
            int ret = Database.GetInstance().ExecuteNonQuery(command);
            Database.GetInstance().Close();
            return ret;
        }
        public DietPlan Select(int id)
        {
            Database.GetInstance().Connect();
            OracleCommand command = Database.GetInstance().CreateCommand(SQL_SELECT_ID);

            command.Parameters.AddWithValue(":id", id);
            OracleDataReader reader = Database.GetInstance().Select(command);

            Collection<DietPlan> plans = Read(reader);
            DietPlan plan = null;
            if (plans.Count == 1)
            {
                plan = plans[0];
            }
            reader.Close();
            Database.GetInstance().Close();
            return plan;
        }
        public int SelectMaxId() // spíše do domain?
        {
            return Select().Max(t => t.Dpid);

        }
        public Collection<DietPlan> Select()
        {
            Database.GetInstance().Connect();


            OracleCommand command = Database.GetInstance().CreateCommand(SQL_SELECT);
            OracleDataReader reader = Database.GetInstance().Select(command);

            Collection<DietPlan> plans = Read(reader);
            reader.Close();

            Database.GetInstance().Close();

            return plans;
        }
        public int Delete(int id)
        {
            Database.GetInstance().Connect();
            OracleCommand command = Database.GetInstance().CreateCommand(SQL_DELETE_ID);

            command.Parameters.AddWithValue(":id", id);
            int ret = Database.GetInstance().ExecuteNonQuery(command);

            Database.GetInstance().Close();
            return ret;
        }

        public Collection<DietPlan> SelectUserDietPlans(int user)
        {
            Collection<DietPlan> ret = new Collection<DietPlan>();

            foreach (DietPlan dp in Select())
            {
                if (dp.User_Id == user)
                    ret.Add(dp);
            }

            return ret;
        }

        public Collection<DietPlan> SelectUserDietPlans(int user, DateTime time)
        {
            Collection<DietPlan> ret = new Collection<DietPlan>();

            foreach (DietPlan dp in Select())
            {
                if (dp.User_Id == user && time.Date == dp.Dpdate.Date)
                {
                    dp.Consumable = new ConsumablesMapper().Select(dp.Consumables_Id);
                    ret.Add(dp);
                }
                    
            }

            return ret;
        }
    }
}
