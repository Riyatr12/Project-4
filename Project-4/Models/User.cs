namespace Project_4.Models
{
    public class User
    {
        private int userId;
        private string userName;
        private string password;
        private bool rememberMe;
        public User() { }

        public User(int userId, string userName, string password, bool rememberMe)
        {
            this.userId = userId;
            this.userName = userName;
            this.password = password;
            this.rememberMe = rememberMe;
        }

        public int UserId { 
            get { return userId; } 
            set { userId = value; }
        
        }
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public bool RememberMe
        {
            get { return rememberMe; }
            set { rememberMe = value; }
        }
    }
}
