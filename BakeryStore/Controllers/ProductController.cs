using BakeryStore.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BakeryStore.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProducts _products;

        public ProductController(IProducts products) 
        {
            _products = products;
        }

        [HttpGet]
        public IActionResult List()
        {
            return View(_products.GetProducts());
        }
    }
}
