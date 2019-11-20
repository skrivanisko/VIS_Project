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
    public class ConsumablesMapper : IDataMapper<Consumable>
    {
        public static String SQL_SELECT = "SELECT * FROM Consumables";
        public static String SQL_SELECT_ID = "SELECT * FROM Consumables WHERE cid=:id";
        public static String SQL_INSERT = "INSERT INTO Consumables"
            + " VALUES (:id, :name, :category, :portion, :calories, :protein, :carbs, :sugar, :fat, :fiber, :manufacturer_id)";
        public static String SQL_DELETE_ID = "DELETE FROM Consumables WHERE cid=:id";
        public static String SQL_UPDATE = "UPDATE Consumables SET name=:name, category=:category, portion =:portion, calories=:calories, protein=:protein," +
            "carbs=:carbs, sugar=:sugar, fat=:fat," +
            "fiber=:fiber, Manufacturer_id=:manufacturer_id WHERE cid=:id";
        public static String SQL_CATEGORY = "select * from consumables where category =: category";
        public static String SQL_SELECT_NAME = "select * from consumables where name =: name";

        private static void PrepareCommand(OracleCommand command, Consumable con)
        {

            command.BindByName = true;
            command.Parameters.AddWithValue(":id", con.Cid);
            command.Parameters.AddWithValue(":name", con.Name);
            command.Parameters.AddWithValue(":category", con.Category);
            command.Parameters.AddWithValue(":portion", con.Portion);
            command.Parameters.AddWithValue(":calories", con.Calories);
            command.Parameters.AddWithValue(":protein", con.Protein);
            command.Parameters.AddWithValue(":carbs", con.Carbs);
            command.Parameters.AddWithValue(":sugar", con.Sugar);
            command.Parameters.AddWithValue(":fat", con.Fat);
            command.Parameters.AddWithValue(":fiber", con.Fiber);
            command.Parameters.AddWithValue(":manufacturer_id", con.Manufacturer_Id);
        }

        private static Collection<Consumable> Read(OracleDataReader reader)
        {
            Collection<Consumable> Consumables = new Collection<Consumable>();

            while (reader.Read())
            {
                int i = -1;
                Consumable cons = new Consumable();
                cons.Cid = reader.GetInt32(++i);
                cons.Name = reader.GetString(++i);
                cons.Category = reader.GetString(++i);
                cons.Portion = reader.GetInt32(++i);
                cons.Calories = reader.GetInt32(++i);

                if (!reader.IsDBNull(++i))
                    cons.Protein = reader.GetFloat(i);
                else cons.Protein = null;

                if (!reader.IsDBNull(++i))
                    cons.Carbs = reader.GetFloat(i);
                else cons.Carbs = null;

                if (!reader.IsDBNull(++i))
                    cons.Sugar = reader.GetFloat(i);
                else cons.Sugar = null;

                if (!reader.IsDBNull(++i))
                    cons.Fat = reader.GetFloat(i);
                else cons.Fat = null;

                if (!reader.IsDBNull(++i))
                    cons.Fiber = reader.GetFloat(i);
                else cons.Fiber = null;

                cons.Manufacturer_Id = reader.GetInt32(++i);

                Consumables.Add(cons);
            }
            return Consumables;
        }

        public int Update(Consumable con)
        {
            Database.GetInstance().Connect();
            OracleCommand command = Database.GetInstance().CreateCommand(SQL_UPDATE);
            PrepareCommand(command, con);
            int ret = Database.GetInstance().ExecuteNonQuery(command);
            Database.GetInstance().Close();
            return ret;
        }

        public int Insert(Consumable con)
        {
            Database.GetInstance().Connect();
            OracleCommand command = Database.GetInstance().CreateCommand(SQL_INSERT);
            PrepareCommand(command, con);
            int ret = Database.GetInstance().ExecuteNonQuery(command);
            Database.GetInstance().Close();
            return ret;
        }

        public Consumable Select(int id)
        {
            Database.GetInstance().Connect();
            OracleCommand command = Database.GetInstance().CreateCommand(SQL_SELECT_ID);

            command.Parameters.AddWithValue(":id", id);
            OracleDataReader reader = Database.GetInstance().Select(command);

            Collection<Consumable> consumables = Read(reader);
            Consumable con = null;
            if (consumables.Count == 1)
            {
                con = consumables[0];
            }
            reader.Close();
            Database.GetInstance().Close();
            return con;
        }

        public Collection<Consumable> Select(string category = null)
        {
            Database.GetInstance().Connect();

            OracleCommand command;



            if (category != null)
            {
                command = Database.GetInstance().CreateCommand(SQL_CATEGORY);
                command.Parameters.AddWithValue(":category", category);
            }
            else command = Database.GetInstance().CreateCommand(SQL_SELECT);


            OracleDataReader reader = Database.GetInstance().Select(command);

            Collection<Consumable> consumables = Read(reader);
            reader.Close();

            Database.GetInstance().Close();

            return consumables;
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

        public Collection<Consumable> Select()
        {
            Database.GetInstance().Connect();

            OracleCommand command;  
            command = Database.GetInstance().CreateCommand(SQL_SELECT);
            OracleDataReader reader = Database.GetInstance().Select(command);

            Collection<Consumable> consumables = Read(reader);
            reader.Close();

            Database.GetInstance().Close();

            return consumables;
        }

        public Consumable SelectByName(string name)
        {
            foreach(Consumable s in Select())
            {
                if (s.Name == name)
                    return s;
            }
            return null;
        }
    }
}
