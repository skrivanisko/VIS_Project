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
    public class MeasurementsMapper : IDataMapper<Measurement>
    {
        public static String SQL_SELECT = "SELECT * FROM Measurements";
        public static String SQL_SELECT_ID = "SELECT * FROM Measurements WHERE mid=:id";
        public static String SQL_INSERT = "INSERT INTO Measurements"
            + " VALUES (:id, :user_id, :height, :weight, :fat, :waist, :chest, :thighs, :datet)";
        public static String SQL_DELETE_ID = "DELETE FROM Measurements WHERE mid=:id";
        public static String SQL_UPDATE = "UPDATE Measurements SET User_id=:user_id, height=:height, weight=:weight, fat=:fat, waist=:waist," +
            " chest=:chest, thighs=:thighs, mdate=:datet WHERE mid=:user_id";
        public static String SQL_SELECT_USER_MEASUREMENTS = "select * from measurements where User_id =:user_id";
        private static void PrepareCommand(OracleCommand command, Measurement m)
        {
            command.BindByName = true;
            command.Parameters.AddWithValue(":id", m.Mid);
            command.Parameters.AddWithValue(":user_id", m.User_Id);
            command.Parameters.AddWithValue(":height", m.Height);
            command.Parameters.AddWithValue(":weight", m.Weight);
            command.Parameters.AddWithValue(":fat", m.Fat);
            command.Parameters.AddWithValue(":waist", m.Waist);
            command.Parameters.AddWithValue(":chest", m.Chest);
            command.Parameters.AddWithValue(":thighs", m.Thighs);
            command.Parameters.AddWithValue(":datet", m.Mdate);
        }
        private static Collection<Measurement> Read(OracleDataReader reader)
        {
            Collection<Measurement> Measurements = new Collection<Measurement>();

            while (reader.Read())
            {
                int i = -1;
                Measurement m = new Measurement();
                m.Mid = reader.GetInt32(++i);
                m.User_Id = reader.GetInt32(++i);
                m.Height = reader.GetInt32(++i);
                m.Weight = reader.GetFloat(++i);

                if (!reader.IsDBNull(++i))
                    m.Fat = reader.GetFloat(i);
                else m.Fat = null;

                if (!reader.IsDBNull(++i))
                    m.Waist = reader.GetFloat(i);
                else m.Waist = null;

                if (!reader.IsDBNull(++i))
                    m.Chest = reader.GetFloat(i);
                else m.Chest = null;

                if (!reader.IsDBNull(++i))
                    m.Thighs = reader.GetFloat(i);
                else m.Thighs = null;

                m.Mdate = reader.GetDateTime(++i);

                Measurements.Add(m);
            }
            return Measurements;
        }
        public int Update(Measurement m)
        {
            Database.GetInstance().Connect();
            OracleCommand command = Database.GetInstance().CreateCommand(SQL_UPDATE);
            PrepareCommand(command, m);
            int ret = Database.GetInstance().ExecuteNonQuery(command);
            Database.GetInstance().Close();
            return ret;
        }
        public int Insert(Measurement m)
        {
            Database.GetInstance().Connect();
            OracleCommand command = Database.GetInstance().CreateCommand(SQL_INSERT);
            PrepareCommand(command, m);
            int ret = Database.GetInstance().ExecuteNonQuery(command);
            Database.GetInstance().Close();
            return ret;
        }
        public Measurement Select(int id)
        {
            Database.GetInstance().Connect();
            OracleCommand command = Database.GetInstance().CreateCommand(SQL_SELECT_ID);

            command.Parameters.AddWithValue(":id", id);
            OracleDataReader reader = Database.GetInstance().Select(command);

            Collection<Measurement> ms = Read(reader);
            Measurement m = null;
            if (ms.Count == 1)
            {
                m = ms[0];
            }
            reader.Close();
            Database.GetInstance().Close();
            return m;
        }
        public Collection<Measurement> Select()
        {
            Database.GetInstance().Connect();


            OracleCommand command = Database.GetInstance().CreateCommand(SQL_SELECT);
            OracleDataReader reader = Database.GetInstance().Select(command);

            Collection<Measurement> ms = Read(reader);
            reader.Close();

            Database.GetInstance().Close();

            return ms;
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

        public Collection<Measurement> SelectUserMeas(int user)
        {
            Collection<Measurement> ret = new Collection<Measurement>();

            foreach(Measurement m in Select())
            {
                if (m.User_Id == user)
                    ret.Add(m);
            }

            return ret;
        }

    }
}
