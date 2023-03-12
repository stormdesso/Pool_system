namespace Pool_system.Models.Classes
{
    public class User
    {
        public User(string sessionId, string login, string password)
        {
            SessionId = sessionId ?? throw new ArgumentNullException(nameof(sessionId));
            Login = login ?? throw new ArgumentNullException(nameof(login));
            Password = password ?? throw new ArgumentNullException(nameof(password));
        }

        public string SessionId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
