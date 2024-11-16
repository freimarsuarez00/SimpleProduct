using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleProduct.Models;
using SimpleProduct.Services.Contracts;

namespace SimpleProduct.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }


        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProductAsync()
        {
            try
            {
                var product = _productService.GetProductAsync();
                return Ok(product);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("FilterByCategory/{categoryId:int}")]
        public async Task<ActionResult<List<Product>>> GetProductByCategoryAsync(int categoryId)
        {
            try
            {
                var product = await _productService.GetProductByCategoryAsync(categoryId);
                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{productId:int}")]
        public async Task<ActionResult<Product>> GetProductByIdAsync(int productId)
        {
            try
            {
                var product = await _productService.GetProductByIdAsync(productId);
                if (product != null) return Ok(product);
                return NotFound();
                    

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public async Task<ActionResult<Product>> AddProductAsync(Product product)
        {
            try
            {
                var saveProduct = await _productService.AddProductAsync(product);
                return CreatedAtAction("GetById", new { productId = saveProduct.ProductId }, saveProduct);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{product:int}")]
        public async Task<ActionResult> DeleteProductAsync(int productId)
        {
            try
            {
                await _productService.DeleteProductAsync(productId);
                return Ok("Producto eliminado correctamente");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<Product>> UpdateProductAsync(Product product)
        {
            try
            {
                var updateProduct = await _productService.UpdateProductAsync(product);
                return Ok(updateProduct);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
