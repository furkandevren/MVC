using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ProductsController : Controller
    {
        private AppDbContext _context;

        private readonly ProductRepository _productRepository;
        public ProductsController(AppDbContext context)
        {
            //DI Container
            //Dependency Injection Pattern
            _productRepository = new ProductRepository();

            _context = context;
            //Linq method
            if (!_context.Products.Any())
            {
                _context.Products.Add(new Product() { Name = "Kalem 1", Price = 100, Stock = 100, Color = "Red"});
                _context.Products.Add(new Product() { Name = "Kalem 2", Price = 100, Stock = 200, Color = "Red"});
                _context.Products.Add(new Product() { Name = "Kalem 3", Price = 100, Stock = 300, Color = "Red"});

                _context.SaveChanges();
            }

        }
        public IActionResult Index()
        {
            var products = _context.Products.ToList();

            var product = _context.Products.First();

            return View(products);
        }

        public IActionResult Remove(int id)
        {
            var product = _context.Products.Find(id);

            _context.Products.Remove(product);

            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Add()
        {
            return View();
        }

        public IActionResult Update(int id)
        {
            return View();
        }
    }
}
