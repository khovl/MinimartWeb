using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinimartWeb.Data
{
    [Table("tdCategory")]
    public class tdCategoryEntity
    {
        [Key]
        public int CateId { get; set; }
        public string CateName { get; set; }
    }
}
