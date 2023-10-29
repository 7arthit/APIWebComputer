using ExWebComputer.Model;
using ExWebComputer.Repositories;
using ExWebComputer.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExWebComputer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsControllers : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsControllers(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public ActionResult GetProducts()
        {
            return Ok(_productService.GetProducts());
        }


        [HttpGet("{id}")]
        public ActionResult GetProduct(int id)
        {
            Product? product = _productService.GetProduct(id);
            if (product == null) return NotFound(new Product());
            return Ok(product);
        }
    }
}
