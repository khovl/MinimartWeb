using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinimartWeb.Data
{
    [Table("tdBlog")]
    public class tdBlogEntity
    {
        [Key]
        public int BlogId { get; set; }
        public string BlogTilte { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public DateTime CreateDate { get; set; }
        public string ImgBlog { get; set; }
        public bool IsHotNews { get; set; }
    }
}
