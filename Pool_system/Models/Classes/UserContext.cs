using MySql.Data.MySqlClient;
using System.Data;

namespace Pool_system.Models.Classes
{
    public class UserContext
    {
        public string ConnectionString { get; set; }

        public UserContext(string connectionString)
        {
            ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }


        public bool TryLogInUser(string login, string password)
        {
            bool state = false;

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
                         & password == reader.GetString("Password")
                          )
                        {
                            //conn.Close();
                            state = true;
                        }

                    }
                }

            }


            return state;
        }

        public bool TryRegistrationUser(string login, string password)
        {
            bool state = false;

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

                //тут ошибка 
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

                    if (insertCmd.ExecuteNonQuery() == 1)
                    {
                        //conn.Close();
                        state = true;
                    }
                }
            }

            return state;
        }

        public void PutTokenInDb(string token, AuthorizationModel model)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlParameter loginParam = new MySqlParameter("@login", model.Login);
                MySqlParameter passswordParam = new MySqlParameter("@password", model.Password);
                MySqlParameter tokenParam = new MySqlParameter("@token", token);

                MySqlCommand putTokenCmd = new MySqlCommand(
                    "UPDATE\r\n    users\r\nSET\r\n    " +
                    "Token = @token\r\n" +
                    "WHERE\r\n    " +
                    "(Login = @login and Password = @password);"
                , conn);

                putTokenCmd.Parameters.Add(loginParam);
                putTokenCmd.ExecuteNonQuery();                
            }
        }

        /*
        public User GetUserDataBySessionID(string sessionID)
        {
            //bool state = false;
            string login = "";
            string pasword = "";


            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();

                MySqlParameter sessionIDParam = new MySqlParameter("@sessionID", sessionID);
                MySqlCommand cmd = new MySqlCommand(
                    "SELECT * FROM users \r\n\t" +
                        "WHERE (ID_Session = @sessionID);"
                , conn);
                cmd.Parameters.Add(sessionIDParam);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    int numberOfSession = 0;
                    while (reader.Read())
                    {
                        login = reader.GetString("Login");
                        pasword = reader.GetString("Password");

                        numberOfSession++;
                    }
                    if (numberOfSession > 1)
                        return null;
                        //state = false;

                }
            }



            return null;
        }
        */
    }
}

