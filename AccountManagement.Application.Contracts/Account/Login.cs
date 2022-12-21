namespace AccountManagement.Application.Contracts.Account
{
    public class Login
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Verifycode { get; set; }

        public Login()
        {

        }
        public Login(string username, string password, string verifycode)
        {
            Username = username;
            Password = password;
            Verifycode = verifycode;
        }
    }
}
