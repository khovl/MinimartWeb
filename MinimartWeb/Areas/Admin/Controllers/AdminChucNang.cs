using Microsoft.AspNetCore.Mvc;
using MinimartWeb.Data;
using MinimartWeb.Models;
using System.Security.Cryptography.X509Certificates;

namespace MinimartWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminChucNang : Controller
    {
        private readonly DB_MinimartContext _db;
        private readonly IWebHostEnvironment _enviroment;
        public AdminChucNang(DB_MinimartContext db, IWebHostEnvironment enviroment)
        {
                _db = db;
                _enviroment = enviroment;
        }
        [Area("Admin")]
        public IActionResult Product()
        {
            var test = from c in _db.CategoryEntity
                       select new Category()
                       {
                           CateId = c.CateId,
                           CateName = c.CateName,
                       };
            List<Category> cate = test.ToList();
            return View(cate);
        }
        //thêm sp
        [Area("Admin")]
        [HttpPost]
        public IActionResult AddProduct([FromBody] Product product)
        {
            bool isHosting = true;
            if (product.IsHotString == "1")
            {
                isHosting = true;
            }
            else
            {
                isHosting = false;
            }
            var add = new tdProductEntity
            {
                ProductName = product.ProductName,
                CateId = product.CateId,
                PriceProduct = product.PriceProduct,
                Discount = product.Discount,
                IsHot = isHosting,
                Stock = product.Stock,
                ImgProduct = product.ImgProduct
            };
            _db.ProductEntity.Add(add);
            var x = _db.SaveChanges();
            return Ok(x);
        }
        //Chỉnh sửa sp
        [Area("Admin")]
        public IActionResult EditProduct(int id)
        {
            var product = from p in _db.ProductEntity
                          join c in _db.CategoryEntity
                          on p.CateId equals c.CateId
                          where p.ProductId == id
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
        [HttpPost]
        public IActionResult EditProductItem([FromBody] Product product)
        {
            bool isHosting = true;
            if (product.IsHotString == "1")
            {
                isHosting = true;
            }
            else
            {
                isHosting = false;
            }
            var edit = _db.ProductEntity.Find(product.ProductId);
            edit.ProductName = product.ProductName; 
            edit.PriceProduct = product.PriceProduct;
            edit.IsHot = isHosting; 
            edit.ImgProduct = product.ImgProduct;
            edit.Discount = product.Discount;
            _db.ProductEntity.Update(edit);
            var x = _db.SaveChanges();
            return Ok(x);
        }
        //Xóa sp
        public IActionResult DeleteProduct(int id)
        {
            var del = _db.ProductEntity.Find(id);
            _db.ProductEntity.Remove(del);
            _db.SaveChanges();
            return Redirect("/Admin/home/index");
        }

        //Uplaod ảnh
        [Area("Admin")]
        [HttpPost]
        public IActionResult UploadImageProduct(IFormFile imageUpload)
        {
            if (imageUpload == null)
                return Json(new FileUpload()
                {
                    Status = "error",
                    Message = "File không tồn tại"
                });
            var fullPath = Path.Combine(_enviroment.WebRootPath, "image", imageUpload.FileName); // upload là foder
            using (var fileStream = new FileStream(fullPath, FileMode.Create))
            {
                imageUpload.CopyTo(fileStream);
            }
            return Json(new FileUpload()
            {
                FileName = imageUpload.FileName.ToString(),
                FilePath = Path.Combine("/image", imageUpload.FileName),
                Status = "success",
                Message = "Upload file thành công!"
            });
        }
        public class FileUpload
        {
            public string FileName { get; set; }
            public string FilePath { get; set; }
            public string Status { get; set; }
            public string Message { get; set; }
        }

        // Tin tức
        public IActionResult Blog()
        {
            var test = from c in _db.BlogEntity
                       select new Blog()
                       {
                            BlogId = c.BlogId,
                            BlogTilte = c.BlogTilte,
                            ImgBlog = c.ImgBlog,
                            Content = c.Content,
                            Author  = c.Author,
                            IsHotNews = c.IsHotNews,
                            CreateDate = c.CreateDate,
                       };
            List<Blog> blog = test.ToList();
            return View(blog);
        }

        [Area("Admin")]
        [HttpPost]
        // Thêm tin tức
        public IActionResult AddBlog([FromBody] Blog blog)
        {
            bool IsHotString = true;
            if (blog.IsHotNewsString == "1")
            {
                IsHotString = true;
            }
            else
            {
                IsHotString = false;
            }
            var add = new tdBlogEntity
            {
                BlogTilte =blog.BlogTilte,
                ImgBlog = blog.ImgBlog,
                Content = blog.Content,
                Author = blog.Author,
                IsHotNews = IsHotString,
                CreateDate = DateTime.Now,
            };
            _db.BlogEntity.Add(add);
            var x = _db.SaveChanges();
            return Ok(x);
        }
        //edit tin tức
        [Area("Admin")]
        public IActionResult EditBlog(int id)
        {
            var blog = from p in _db.BlogEntity                        
                          where p.BlogId == id
                          select new Blog()
                          {
                          BlogId = p.BlogId,
                          BlogTilte = p.BlogTilte,
                          ImgBlog = p.ImgBlog,
                          Content = p.Content,
                          Author = p.Author,
                          IsHotNews = p.IsHotNews,
                          CreateDate = p.CreateDate,                         
                          };
            List<Blog> blogs = blog.ToList();
            return View(blogs);
        }

        [Area("Admin")]
        [HttpPost]
        public IActionResult EditBlogItem([FromBody] Blog blog)
        {
            bool IsHotString = true;
            if (blog.IsHotNewsString == "1")
            {
                IsHotString = true;
            }
            else
            {
                IsHotString = false;
            }
            var edit = _db.BlogEntity.Find(blog.BlogId);
            edit.BlogTilte = blog.BlogTilte;
            edit.ImgBlog = blog.ImgBlog;
            edit.Author = blog.Author;
            edit.Content = blog.Content;
            edit.IsHotNews = IsHotString;
            edit.CreateDate = blog.CreateDate;
            _db.BlogEntity.Update(edit);
            var x = _db.SaveChanges();
            return Ok(x);
        }
        //xóa tin tức
        public IActionResult DeleteBlog(int id)
        {
            var del = _db.BlogEntity.Find(id);
            _db.BlogEntity.Remove(del);
            _db.SaveChanges();
            return Redirect("/Admin/home/ViewBlog");
        }
    }
}
