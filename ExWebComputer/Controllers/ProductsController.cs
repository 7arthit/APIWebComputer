using ExWebComputer.Model;
using ExWebComputer.Service;
using Microsoft.AspNetCore.Mvc;

namespace ExWebComputer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        //---------- การ injection ----------//

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        //---------- ค้นหา สินค้า ----------//

        [HttpGet]
        public ActionResult GetProducts([FromQuery]string? search, int? typeId, int? page, int? per_page)
        {
            return Ok(_productService.GetProducts(search, typeId, page, per_page));
        }

        //---------- ค้นหา สินค้า ด้วย id ----------//

        [HttpGet("{id}")]
        public ActionResult GetProduct(int id)
        {
            Product? product = _productService.GetProduct(id);
            if (product == null) return NotFound("Product Notfound");
            return Ok(product);
        }

        //---------- เพิ่ม สินค้า ----------//

        [HttpPost]
        public ActionResult AddProduct([FromBody]Product product)
        {
            var addedProduct = _productService.CreatProduct(product);
            return CreatedAtAction(nameof(AddProduct), new { id = addedProduct.Id}, product);
        }

        //---------- แก้ไข สินค้า ----------//

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

        //---------- ลบ สินค้า ----------//

        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(int id)
        {
            Product? product = _productService.DeleteProduct(id);
            if (product == null) return NotFound("Product Notfound");
            return NoContent();
        }
    }
}
