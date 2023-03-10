using MySql.Data.MySqlClient;

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
    }
}

