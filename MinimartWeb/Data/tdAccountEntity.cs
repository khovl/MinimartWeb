using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinimartWeb.Data
{
    [Table("tdAccount")]
    public class tdAccountEntity
    {
        [Key]
        public int AccountId { get; set; }
        public string Email { get; set; }
        public string PasswordAccount { get; set; }
        public bool IsAdmin { get; set; }
    }
}
