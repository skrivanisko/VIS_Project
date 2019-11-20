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
    public class UsersMapper : IDataMapper<User>
    {
        public static String SQL_SELECT = "SELECT * FROM users";
        public static String SQL_SELECT_ID = "SELECT * FROM users WHERE userid=:id";
        public static String SQL_SELECT_LOGIN = "SELECT * FROM users WHERE login=:login";
        public static String SQL_INSERT = "INSERT INTO users"
            + " VALUES (:id, :login, :password, :email, :name, :surname, :birthday, :admin)";
        public static String SQL_DELETE_ID = "DELETE FROM users WHERE userid=:id";
        public static String SQL_UPDATE = "UPDATE users SET login=:login, password=:password, email=:email, name=:name, surname=:surname," +
            "birthday=:birthday, admin=::admin WHERE userid=:id";

        private static void PrepareCommand(OracleCommand command, User user)
        {
            command.BindByName = true;
            command.Parameters.AddWithValue(":id", user.Userid);
            command.Parameters.AddWithValue(":login", user.Login);
            command.Parameters.AddWithValue(":password", user.Password);
            command.Parameters.AddWithValue(":email", user.Email);
            command.Parameters.AddWithValue(":name", user.Name);
            command.Parameters.AddWithValue(":surname", user.Surname);
            command.Parameters.AddWithValue(":birthday", user.Birthday);
            command.Parameters.AddWithValue(":admin", user.Admin);
        }
        private static Collection<User> Read(OracleDataReader reader)
        {
            Collection<User> Users = new Collection<User>();

            while (reader.Read())
            {
                int i = -1;
                User User = new User();
                User.Userid = reader.GetInt32(++i);
                User.Login = reader.GetString(++i);
                User.Password = reader.GetString(++i);
                User.Email = reader.GetString(++i);
                User.Name = reader.GetString(++i);
                User.Surname = reader.GetString(++i);
                User.Birthday = reader.GetDateTime(++i);
                User.Admin = reader.GetInt32(++i);

                Users.Add(User);
            }
            return Users;
        }

        public int Update(User user)
        {
            Database.GetInstance().Connect();
            OracleCommand command = Database.GetInstance().CreateCommand(SQL_UPDATE);
            PrepareCommand(command, user);
            int ret = Database.GetInstance().ExecuteNonQuery(command);
            Database.GetInstance().Close();
            return ret;
        }

        public int Insert(User user)
        {
            Database.GetInstance().Connect();
            OracleCommand command = Database.GetInstance().CreateCommand(SQL_INSERT);
            PrepareCommand(command, user);
            int ret = Database.GetInstance().ExecuteNonQuery(command);
            Database.GetInstance().Close();
            return ret;
        }

        public User Select(int id)
        {
            Database.GetInstance().Connect();
            OracleCommand command = Database.GetInstance().CreateCommand(SQL_SELECT_ID);

            command.Parameters.AddWithValue(":id", id);
            OracleDataReader reader = Database.GetInstance().Select(command);

            Collection<User> users = Read(reader);
            User user = null;
            if (users.Count == 1)
            {
                user = users[0];
            }
            reader.Close();
            Database.GetInstance().Close();
            return user;
        }

        public Collection<User> Select()
        {
            Database.GetInstance().Connect();


            OracleCommand command = Database.GetInstance().CreateCommand(SQL_SELECT);
            OracleDataReader reader = Database.GetInstance().Select(command);

            Collection<User> Users = Read(reader);
            reader.Close();

            Database.GetInstance().Close();

            return Users;
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

        public User FindUserByLogin(string login)
        {
            foreach (User u in Select())
            {
                if (u.Login == login)
                    return u;
            }

            return null;
        }

        public int SelectNextFreeID()
        {
            return Select().Max(x => x.Userid)+1;
        }
    }
}
