using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using Domain_Layer.Entities;
using System.Collections.ObjectModel;

namespace Data_Layer.DataMapper
{
    public class ManufacturerMapper : IDataMapper<Manufacturer>
    {
        public static String SQL_SELECT = "SELECT * FROM Manufacturer";
        public static String SQL_INSERT = "INSERT INTO Manufacturer"
            + " VALUES (:id, :name)";
        public static String SQL_DELETE_ID = "DELETE FROM Manufacturer WHERE manid=:id";
        public static String SQL_UPDATE = "UPDATE Manufacturer SET name=:name WHERE manid=:id";

        public int Delete(int id)
        {
            Database.GetInstance().Connect();
            OracleCommand command = Database.GetInstance().CreateCommand(SQL_DELETE_ID);

            command.Parameters.AddWithValue(":id", id);
            int ret = Database.GetInstance().ExecuteNonQuery(command);

            Database.GetInstance().Close();
            return ret;
        }

        public int Insert(Manufacturer man)
        {
            Database.GetInstance().Connect();
            OracleCommand command = Database.GetInstance().CreateCommand(SQL_INSERT);
            PrepareCommand(command, man);
            int ret = Database.GetInstance().ExecuteNonQuery(command);
            Database.GetInstance().Close();
            return ret;
        }

        private void PrepareCommand(OracleCommand command, Manufacturer man)
        {
            command.BindByName = true;
            command.Parameters.AddWithValue(":id", man.Manid);
            command.Parameters.AddWithValue(":name", man.Name);
        }

        private Collection<Manufacturer> Read(OracleDataReader reader)
        {
            Collection<Manufacturer> Manufacturers = new Collection<Manufacturer>();

            while (reader.Read())
            {
                int i = -1;
                Manufacturer mans = new Manufacturer();
                mans.Manid = reader.GetInt32(++i);
                mans.Name = reader.GetString(++i);

                Manufacturers.Add(mans);
            }
            return Manufacturers;
        }

        public Collection<Manufacturer> Select()
        {
            Database.GetInstance().Connect();

            OracleCommand command = Database.GetInstance().CreateCommand(SQL_SELECT);
            OracleDataReader reader = Database.GetInstance().Select(command);

            Collection<Manufacturer> manufacturers = Read(reader);
            reader.Close();

            Database.GetInstance().Close();

            return manufacturers;
        }

        

        public int Update(Manufacturer man)
        {
            Database.GetInstance().Connect();
            OracleCommand command = Database.GetInstance().CreateCommand(SQL_UPDATE);
            PrepareCommand(command, man);
            int ret = Database.GetInstance().ExecuteNonQuery(command);
            Database.GetInstance().Close();
            return ret;
        }
    }
}
