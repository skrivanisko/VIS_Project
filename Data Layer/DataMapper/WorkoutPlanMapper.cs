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
    public class WorkoutPlanMapper : IDataMapper<WorkoutPlan>
    {
        public static String SQL_SELECT = "SELECT * FROM WorkoutPlan";
        public static String SQL_SELECT_ID = "SELECT * FROM WorkoutPlan WHERE wpid=:id";
        public static String SQL_INSERT = "INSERT INTO WorkoutPlan"
            + " VALUES (:id, :user_id, :activity, :amount, :datet)";
        public static String SQL_DELETE_ID = "DELETE FROM WorkoutPlan WHERE wpid=:id";
        public static String SQL_UPDATE = "UPDATE WorkoutPlan SET User_id=:user_id, Activities_id=:activity, amount=:amount, wpdate=:datet WHERE wpid=:id";

        private static void PrepareCommand(OracleCommand command, WorkoutPlan plan)
        {
            command.BindByName = true;
            command.Parameters.AddWithValue(":id", plan.Wpid);
            command.Parameters.AddWithValue(":user_id", plan.User_Id);
            command.Parameters.AddWithValue(":activity", plan.Activities_Id);
            command.Parameters.AddWithValue(":amount", plan.Amount);
            command.Parameters.AddWithValue(":datet", plan.Wpdate);
        }
        private static Collection<WorkoutPlan> Read(OracleDataReader reader)
        {
            Collection<WorkoutPlan> Diet_Plans = new Collection<WorkoutPlan>();

            while (reader.Read())
            {
                int i = -1;
                WorkoutPlan plan = new WorkoutPlan();
                plan.Wpid = reader.GetInt32(++i);
                plan.User_Id = reader.GetInt32(++i);
                plan.Activities_Id = reader.GetInt32(++i);
                plan.Amount = reader.GetFloat(++i);
                plan.Wpdate = reader.GetDateTime(++i);

                Diet_Plans.Add(plan);
            }
            return Diet_Plans;
        }
        public int Update(WorkoutPlan plan)
        {
            Database.GetInstance().Connect();
            OracleCommand command = Database.GetInstance().CreateCommand(SQL_UPDATE);
            PrepareCommand(command, plan);
            int ret = Database.GetInstance().ExecuteNonQuery(command);
            Database.GetInstance().Close();
            return ret;
        }
        public int Insert(WorkoutPlan plan)
        {
            Database.GetInstance().Connect();
            OracleCommand command = Database.GetInstance().CreateCommand(SQL_INSERT);
            PrepareCommand(command, plan);
            int ret = Database.GetInstance().ExecuteNonQuery(command);
            Database.GetInstance().Close();
            return ret;
        }
        public WorkoutPlan Select(int id)
        {
            Database.GetInstance().Connect();
            OracleCommand command = Database.GetInstance().CreateCommand(SQL_SELECT_ID);

            command.Parameters.AddWithValue(":id", id);
            OracleDataReader reader = Database.GetInstance().Select(command);

            Collection<WorkoutPlan> plans = Read(reader);
            WorkoutPlan plan = null;
            if (plans.Count == 1)
            {
                plan = plans[0];
            }
            reader.Close();
            Database.GetInstance().Close();
            return plan;
        }
        public Collection<WorkoutPlan> Select()
        {
            Database.GetInstance().Connect();


            OracleCommand command = Database.GetInstance().CreateCommand(SQL_SELECT);
            OracleDataReader reader = Database.GetInstance().Select(command);

            Collection<WorkoutPlan> plans = Read(reader);
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

        public Collection<WorkoutPlan> SelectUserWorkoutPlans(int user)
        {
            Collection<WorkoutPlan> ret = new Collection<WorkoutPlan>();

            foreach (WorkoutPlan wp in Select())
            {
                if (wp.User_Id == user)
                    ret.Add(wp);
            }

            return ret;
        }
    }
}
