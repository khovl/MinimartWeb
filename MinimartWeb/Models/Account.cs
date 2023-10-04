namespace MinimartWeb.Models
{
    public class Account
    {
        public int AccountId { get; set; }
        public string Email { get; set; }
        public string PasswordAccount { get; set; }
        public bool IsAdmin { get; set; }
    }
}
