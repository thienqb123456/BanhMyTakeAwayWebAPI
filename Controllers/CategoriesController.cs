using Microsoft.AspNetCore.Mvc;
using ThienAspWebApi.Models;
using ThienAspWebApi.Repository.RepositoryWrapper;

namespace ThienAspWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IRepositoryWrapper _repo;

        public CategoriesController(IRepositoryWrapper repo)
        {
            _repo = repo;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            try
            {
                var categories = await _repo.CategoryRepo.GetAllCategoriesAsync();
                return Ok(categories);
            } catch
            {
                return BadRequest();
            }
            
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            var category = await _repo.CategoryRepo.GetCategoryByIdAsync(id);

            if (category == null) { return NotFound($"not found cate has id = {id}"); }

            return Ok(category);
        }

        // POST: api/Categories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(Category category)
        {
            if (_repo.CategoryRepo == null)
            {
                return Problem("Entity set 'AppStoreContext.Categories'  is null.");
            }
            _repo.CategoryRepo.CreateCategory(category);
            await _repo.SaveAsync();

            return CreatedAtAction("GetCategory", new { id = category.Id }, category);
        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, Category category)
        {
            if (id != category.Id)
            {
                return BadRequest();
            }
            _repo.CategoryRepo.UpdateCategory(category);
            await _repo.SaveAsync();
            return NoContent();
        }



        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            if (_repo.CategoryRepo == null)
            {
                return NotFound($"Not found any category");
            }
            var category = await _repo.CategoryRepo.GetCategoryByIdAsync(id);
            if (category == null) { return NotFound($"Not found cate has id = {id}"); }

            _repo.CategoryRepo.DeleteCategory(category);
            await _repo.SaveAsync();

            return NoContent();
        }

    }
}
