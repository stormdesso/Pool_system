using MySql.Data.MySqlClient;
using System.Data;

namespace Pool_system.Models
{
    public class UserContext
    {
        public string ConnectionString { get; set; }

        public UserContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }


        public bool TryLogInUser(string login, string password)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlParameter param = new MySqlParameter("@login", login);
                MySqlCommand cmd = new MySqlCommand(
                    "SELECT * FROM users\r\n\t" +
                    "WHERE (users.Login = @login);"
                , conn);

                cmd.Parameters.Add(param);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (login == reader.GetString("Login")
                         & (password == reader.GetString("Password"))
                          )
                        {
                            return true;
                        }

                    }
                }

            }

            return false;
        }

        public bool TryRegistrationUser(string login, string password)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlParameter loginParam = new MySqlParameter("@login", login);
                MySqlParameter passswordParam = new MySqlParameter("@password", password);
                MySqlCommand getRecordCmd = new MySqlCommand(
                    "SELECT count(*) FROM users\r\n\t" +
                    "WHERE (users.Login = @login);"
                , conn);

                getRecordCmd.Parameters.Add(loginParam);

                int numberOfRecords = 0;
                using (MySqlDataReader reader = getRecordCmd.ExecuteReader())
                {
                    numberOfRecords = reader.GetInt16("COUNT(*)");
                }

                if (numberOfRecords == 0) 
                {
                    var insertCmd = new MySqlCommand("INSERT INTO users (Login, Password) VALUES ();");
                    insertCmd.Parameters.Add(loginParam);
                    insertCmd.Parameters.Add(passswordParam);

                    if (insertCmd.ExecuteNonQuery() != 1) 
                    { 
                        return false;
                    }   
                }
            }

            return false;
        }
    }
}

