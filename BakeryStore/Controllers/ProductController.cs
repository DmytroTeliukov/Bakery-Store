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

        [HttpGet]
        public IActionResult ListByCategory(String categoryName)
        {
            return View("List", _products.GetProductsByCategory(categoryName));
        }

        [HttpGet]
        public IActionResult Profile(int id)
        {

            return View(_products.GetProductById(id));
        }


    }
}
