using ExWebComputer.Model;
using ExWebComputer.Repositories;
using ExWebComputer.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

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
        public ActionResult GetProducts([FromQuery]string? search, int? typeId, int? page, int? per_page)
        {
            return Ok(_productService.GetProducts(search, typeId, page, per_page));
        }

        [HttpGet("{id}")]
        public ActionResult GetProduct(int id)
        {
            Product? product = _productService.GetProduct(id);
            if (product == null) return NotFound("Product Notfound");
            return Ok(product);
        }

        [HttpPost]
        public ActionResult AddProduct([FromBody]Product product)
        {
            var addedProduct = _productService.CreatProduct(product);
            return CreatedAtAction(nameof(AddProduct), new { id = addedProduct.Id}, product);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateProduct(int id, Product product)
        {
            if (product.Id == id)
            {
                var update = _productService.UpdateProduct(product);
                return Ok(update);
            }
            return BadRequest("update filed");
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(int id)
        {
            Product? product = _productService.DeleteProduct(id);
            if (product == null) return NotFound("Product Notfound");
            return NoContent();
        }
    }
}
