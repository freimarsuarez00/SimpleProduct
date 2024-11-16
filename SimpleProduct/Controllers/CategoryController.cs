using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleProduct.Models;
using SimpleProduct.Services.Contracts;

namespace SimpleProduct.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Category>>> GetCategoriesAsync()
        {
            try
            {
                var categories = await _categoryService.GetCategoriesAsync();
                return Ok(categories);
            }
            catch(Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{categoryId:int}", Name = "GetCategory")]
        public async Task<ActionResult<Category>> GetCategoryByIdAsync(int categoryId)
        {
            try
            {
                var category = await _categoryService.GetCategoryByIdAsync(categoryId);
                if(category != null) return Ok(category);

                return NotFound();
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpPost]
        public async Task<ActionResult<Category>> AddCategoryAsync(Category category)
        {
            try
            {
                var savedCategory = await _categoryService.AddCategoryAsync(category);
                return CreatedAtRoute("GetCategory", new {categoryId = savedCategory.CategoryId}, savedCategory);

            }
            catch(Exception ex)
            {
                Console.WriteLine("Error al guardar los cambios: " + ex.InnerException?.Message);
                throw;
            }
        }


        [HttpDelete("{categoryId:int}")]
        public async Task<IActionResult> DeleteCategoryAsync(int categoryId)
        {
            try
            {
                 await _categoryService.DeleteCategoryAsync(categoryId);
                return NoContent();
            }
            catch(KeyNotFoundException)
            {
                return NotFound("Category no encontrada");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al guardar los cambios: " + ex.InnerException?.Message);
                throw;
            }
        }

    }
}
