using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinimartWeb.Data
{
    [Table("tdProduct")]
    public class tdProductEntity
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int CateId { get; set; }
        public Decimal PriceProduct { get; set; }
        public int Discount { get; set; }
        public bool IsHot { get; set; }
        public int Stock { get; set; }
        public string ImgProduct { get; set; }
    }
}
