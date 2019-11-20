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
    public class ActivitiesMapper : IDataMapper<Activity>
    {
        public static String SQL_SELECT = "SELECT * FROM Activities";
        public static String SQL_SELECT_ID = "SELECT * FROM Activities WHERE aid=:id";
        public static String SQL_INSERT = "INSERT INTO Activities"
            + " VALUES (:id, :name, :category, :duration, :calories)";
        public static String SQL_DELETE_ID = "DELETE FROM Activities WHERE aid=:id";
        public static String SQL_UPDATE = "UPDATE Activities SET name=:name, category=:category, duration =:duration, calories=:calories WHERE aid:=id";

        private static void PrepareCommand(OracleCommand command, Activity ac)
        {
            command.BindByName = true;
            command.Parameters.AddWithValue(":id", ac.Aid);
            command.Parameters.AddWithValue(":name", ac.Name);
            command.Parameters.AddWithValue(":category", ac.Category);
            command.Parameters.AddWithValue(":portion", ac.Duration);
            command.Parameters.AddWithValue(":calories", ac.Calories);
        }
        private static Collection<Activity> Read(OracleDataReader reader)
        {
            Collection<Activity> Activities = new Collection<Activity>();

            while (reader.Read())
            {
                int i = -1;
                Activity acts = new Activity();
                acts.Aid = reader.GetInt32(++i);
                acts.Name = reader.GetString(++i);
                acts.Category = reader.GetString(++i);
                acts.Duration = reader.GetFloat(++i);

                if (!reader.IsDBNull(++i))
                    acts.Calories = reader.GetInt32(i);
                else acts.Calories = null;

                Activities.Add(acts);
            }
            return Activities;
        }
        public int Update(Activity act)
        {

            Database.GetInstance().Connect();
            OracleCommand command = Database.GetInstance().CreateCommand(SQL_UPDATE);
            PrepareCommand(command, act);
            int ret = Database.GetInstance().ExecuteNonQuery(command);
            Database.GetInstance().Close();
            return ret;
        }
        public int Insert(Activity act)
        {
            
            Database.GetInstance().Connect();
            OracleCommand command = Database.GetInstance().CreateCommand(SQL_INSERT);
            PrepareCommand(command, act);
            int ret = Database.GetInstance().ExecuteNonQuery(command);
            Database.GetInstance().Close();
            return ret;
        }
        public Activity Select(int id)
        {
            Database.GetInstance().Connect();
            OracleCommand command = Database.GetInstance().CreateCommand(SQL_SELECT_ID);

            command.Parameters.AddWithValue(":id", id);
            OracleDataReader reader = Database.GetInstance().Select(command);

            Collection<Activity> activities = Read(reader);
            Activity act = null;
            if (activities.Count == 1)
            {
                act = activities[0];
            }
            reader.Close();
            Database.GetInstance().Close();
            return act;
        }
        public Collection<Activity> Select()
        {
            Database.GetInstance().Connect();


            OracleCommand command = Database.GetInstance().CreateCommand(SQL_SELECT);
            OracleDataReader reader = Database.GetInstance().Select(command);

            Collection<Activity> activities = Read(reader);
            reader.Close();

            Database.GetInstance().Close();

            return activities;
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
    }
}
