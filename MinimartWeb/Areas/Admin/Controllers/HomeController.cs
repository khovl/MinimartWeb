using Microsoft.AspNetCore.Mvc;
using MinimartWeb.Data;
using MinimartWeb.Models;

namespace MinimartWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly DB_MinimartContext _db;
        public HomeController(DB_MinimartContext db)
        {
                _db = db;
        }

        [Area("Admin")]
        public IActionResult Index()
        {
            var product = from p in _db.ProductEntity
                          join c in _db.CategoryEntity
                          on p.CateId equals c.CateId
                          select new Product()
                          {
                              ProductId = p.ProductId,
                              ProductName = p.ProductName,
                              PriceProduct = p.PriceProduct,
                              IsHot = p.IsHot,
                              ImgProduct = p.ImgProduct,
                              CateName = c.CateName,
                              Stock = p.Stock,
                              Discount = p.Discount
                          };
            List<Product> products = product.ToList();
            return View(products);
        }
        [Area("Admin")]
        public IActionResult IndexBlog()
        {
            var blog = from p in _db.BlogEntity
                          
                          select new Blog()
                          {
                           BlogId = p.BlogId,
                           BlogTilte = p.BlogTilte,
                           ImgBlog = p.ImgBlog,
                           Author   = p.Author,
                           Content  = p.Content,
                           IsHotNews = p.IsHotNews,
                           CreateDate = p.CreateDate,
                          };
            List<Blog> blogs = blog.ToList();
            return View(blogs);
        }
    }
}
