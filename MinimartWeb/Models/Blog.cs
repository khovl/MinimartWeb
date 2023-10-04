namespace MinimartWeb.Models
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string BlogTilte { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public DateTime CreateDate { get; set; }
        public string ImgBlog { get; set; }
        public bool IsHotNews { get; set; }
        public string IsHotNewsString { get; set; }
    }
}
