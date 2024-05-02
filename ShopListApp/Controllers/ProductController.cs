using Microsoft.AspNetCore.Mvc;
using ShopListApp.Abstractions;
using ShopListApp.Domain.Models;
using ShopListApp.Implementations;

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

            if (!ModelState.IsValid)
                return BadRequest(ModelState); 

            return Ok(product);
        }

        [HttpGet("get-products")]
        public IActionResult GetProducts()
        {
            var products = _productService.GetProducts();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(products);
        }

        [HttpPost("create-product")]
        public IActionResult CreateProduct([FromBody] Product product)
        {

            if (!_productService.CreateProduct(product))
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
