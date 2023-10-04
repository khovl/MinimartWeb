namespace MinimartWeb.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int CateId { get; set; }
        public string CateName { get; set; }
        public Decimal PriceProduct { get; set; }
        public int Discount { get; set; }
        public bool IsHot { get; set; }
        public string IsHotString { get; set; }
        public int Stock { get; set; }
        public string ImgProduct { get; set; }
    }
}
