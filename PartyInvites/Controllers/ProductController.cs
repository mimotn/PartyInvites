using System.Web.Mvc;
using PartyInvites.Domain;
using PartyInvites.Models;
using PartyInvites.Services;

namespace PartyInvites.Controllers
{
    public class ProductController : Controller
    {
        private readonly ICalculator _calculator;

        public ProductController(ICalculator calculator)
        {
            _calculator = calculator;
        }

        // GET: Product
        public ActionResult Index()
        {
            var product = new Product()
            {
                Id = 1,
                Name = "Kayak",
                Description = "A boat for one person",
                Price = 27.33M
            };

            return View(product);
        }

        public ActionResult List()
        {
            var products = new[]
            {
                new Product() {Id = 1, Name = "Asus", Description = "Smartphone", Price = 3M, Category = Category.Discount}, 
                new Product() {Id = 2, Name = "Acer", Description = "Pc", Price = 5M, Category = Category.Express}, 
                new Product() {Id = 3, Name = "Hp", Description = "Printer", Price = 2M, Category = Category.Supplier}, 
            };

            var model = new ProductListViewModel()
            {
                Products = products,
                TotalPrice = _calculator.TotalPrice(products)
            };

            return View(model);
        }
    }
}