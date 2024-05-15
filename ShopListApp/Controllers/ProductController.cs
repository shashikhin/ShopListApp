using Microsoft.AspNetCore.Mvc;
using ShopListApp.Abstractions;
using ShopListApp.Domain.Models;

namespace ShopListApp.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productService;
        public ProductController(IProductRepository productService) 
        {
            _productService = productService;
        }

        [HttpGet("get-product")]
        public IActionResult GetProductById(int productId)
        {
            var product = _productService.GetProduct(productId);

            if (product == null)
                return BadRequest(ModelState); 

            return Ok(product);
        }

        [HttpGet("get-products")]
        public IActionResult GetProducts()
        {
            var products = _productService.GetProducts();

            if (products == null)
                return BadRequest(ModelState);

            return Ok(products);
        }

        [HttpPost("create-product")]
        public IActionResult CreateProduct([FromQuery] string name, double cost)
        {

            if (!_productService.CreateProduct(name, cost))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpDelete("delete-product")]
        public IActionResult DeleteProduct(int productId)
        {

            if (!_productService.DeleteProduct(productId))
            {
                ModelState.AddModelError("", "Something went wrong while deleting");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpPut("update-product")]
        public IActionResult UpdateProduct([FromBody] Product product)
        {

            if (!_productService.UpdateProduct(product))
            {
                ModelState.AddModelError("", "Something went wrong while updating");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

    }
}
