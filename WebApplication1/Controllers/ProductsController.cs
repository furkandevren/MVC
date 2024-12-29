using Microsoft.AspNetCore.Mvc;
using WebApplication1.Helpers;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ProductsController : Controller
    {
        private AppDbContext _context;

        private IHelper _helper;

        private readonly ProductRepository _productRepository;


        public ProductsController(AppDbContext context, IHelper helper)
        {
            //DI Container
            //Dependency Injection Pattern

            _productRepository = new ProductRepository();
            _helper = helper;
            _context = context;

            //Linq method
            //if (!_context.Products.Any())
            //{
            //    _context.Products.Add(new Product() { Name = "Kalem 1", Price = 100, Stock = 100, Color = "Red" });
            //    _context.Products.Add(new Product() { Name = "Kalem 2", Price = 100, Stock = 200, Color = "Red" });
            //    _context.Products.Add(new Product() { Name = "Kalem 3", Price = 100, Stock = 300, Color = "Red" });

            //    _context.SaveChanges();
            //}

        }
        public IActionResult Index([FromServices] IHelper helper2)
        {
            var text = "Asp.Net";
            var upperText = _helper.Upper(text);

            var status = _helper.Equals(helper2);
            var products = _context.Products.ToList();

            return View(products);
        }

        public IActionResult Remove(int id)
        {
            var product = _context.Products.Find(id);

            _context.Products.Remove(product);

            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]

        public IActionResult Add()
        {
            return View();
        }
        // Sağlıklı olan HttpPost üzerinden almak.(Model Bindin yapmak istediğimizde post.)
        [HttpPost]
        public IActionResult Add(Product newProduct)
        {
            // Request Header-Body 

            //1.Yöntem

            //var name = HttpContext.Request.Form["Name"].ToString();
            //var price = decimal.Parse(HttpContext.Request.Form["Price"].ToString());
            //var stock = int.Parse(HttpContext.Request.Form["Stock"].ToString());
            //var color = HttpContext.Request.Form["Color"].ToString();

            //2.Yöntem
            //Product newProduct = new Product() { Name = Name , Price = Price , Stock = Stock , Color = Color } ;


            _context.Products.Add(newProduct);
            _context.SaveChanges();
            TempData["status"] = "Ürün başarıyla eklendi.";

            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var product = _context.Products.Find(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Update(Product updateProduct, int productId, string type)
        {
            updateProduct.Id = productId;

            _context.Products.Update(updateProduct);
            _context.SaveChanges();
            TempData["status"] = "Ürün başarıyla güncellendi.";
            return RedirectToAction("Index");

        }
    }
}
