using MySql.Data.MySqlClient;
using System.Data;

namespace Pool_system.Models.Classes
{
    public class UsersContext
    {
        public string ConnectionString { get; set; }

        public UsersContext(string connectionString)
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

        public bool TryRegistrationUser(string login, string password, string token)
        {
            bool state = false;

            //using (MySqlConnection conn = GetConnection())
            //{
            //    conn.Open();
            //    MySqlParameter param = new MySqlParameter("@login", login);
            //    MySqlCommand cmd = new MySqlCommand(
            //        "SELECT * FROM users\r\n\t" +
            //        "WHERE (users.Login = @login);"
            //    , conn);

            //    cmd.Parameters.Add(param);

            //    using (MySqlDataReader reader = cmd.ExecuteReader())
            //    {
            //        while (reader.Read())
            //        {
            //            if (login == reader.GetString("Login")                        
            //            {
            //                state = false;
            //            }

            //        }
            //    }

            //}


            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlParameter loginParam = new MySqlParameter("@login", login);
                MySqlParameter passswordParam = new MySqlParameter("@password", password);
                MySqlParameter tokenParam = new MySqlParameter("@token", token);
                MySqlCommand insertRecordCmd = new MySqlCommand(
                    "INSERT INTO users (Login, Password, Token) VALUES (@login, @password, @token);"
                , conn);

                insertRecordCmd.Parameters.Add(loginParam);
                insertRecordCmd.Parameters.Add(passswordParam);
                insertRecordCmd.Parameters.Add(tokenParam);
                try
                {
                    insertRecordCmd.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    int errorcode = ex.Number;                    
                    return false;
                }
                
                state = true;
            }

            return state;
        }

        public bool TryPutTokenInDb(string token, AuthorizationModel model)
        {
            bool state = false;

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
                putTokenCmd.Parameters.Add(passswordParam);
                putTokenCmd.Parameters.Add(tokenParam);
                try
                {
                    putTokenCmd.ExecuteNonQuery();
                    state = true;
                }
                catch (MySqlException ex)
                {
                    int errorcode = ex.Number;
                    state= false;
                }
            }
            return state;
        }
        
        public bool TryPutTokenInDb(string token, RegistrationModel model)
        {
            bool state = false;

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
                putTokenCmd.Parameters.Add(passswordParam);
                putTokenCmd.Parameters.Add(tokenParam);
                try
                {
                    putTokenCmd.ExecuteNonQuery();
                    state = true;
                }
                catch (MySqlException ex)
                {
                    int errorcode = ex.Number;
                    state = false;
                }                           
            }
            return state;
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

