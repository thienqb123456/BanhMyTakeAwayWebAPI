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
        public async Task<IActionResult> GetCategories()
        {
            try
            {
                var categories = await _repo.CategoryRepo.GetAllCategoriesAsync();
                return Ok(categories);
            } catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetCategory(int id)
        {
            try
            {
                var category = await _repo.CategoryRepo.GetCategoryByIdAsync(id);
                if (category == null) { return NotFound($"not found cate has id = {id}"); }
                return Ok(category);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Categories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(Category category)
        {
            try
            {
                _repo.CategoryRepo.CreateCategory(category);
                await _repo.SaveAsync();
                return CreatedAtAction("GetCategory", new { id = category.Id }, category);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, Category category)
        {
            try
            {
                if (id != category.Id)
                {
                    return NotFound(category);
                }
                _repo.CategoryRepo.UpdateCategory(category);
                await _repo.SaveAsync();
                return Ok(category);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            try
            {
                var category = await _repo.CategoryRepo.GetCategoryByIdAsync(id);
                if (category == null) { return NotFound($"Not found category has id = {id}"); }
                _repo.CategoryRepo.DeleteCategory(category);
                await _repo.SaveAsync();
                return Ok($"Deleted category has id {id} successfully! ");
            } catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
