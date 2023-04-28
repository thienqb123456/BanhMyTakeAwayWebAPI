using Microsoft.AspNetCore.Mvc;
using ThienAspWebApi.Models;
using ThienAspWebApi.Repository.RepositoryWrapper;

namespace ThienAspWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeCatesController : ControllerBase
    {
        private readonly IRepositoryWrapper _repo;

        public TypeCatesController(IRepositoryWrapper repo)
        {
            _repo = repo;
        }

        // GET: api/TypeCates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TypeCate>>> GetTypeCates()
        {
          try
            {
                var typecates = await _repo.TypeCateRepo.GetAllTypeCatesAsync();
                return Ok(typecates);
            } catch (Exception ex) { return BadRequest(ex.Message); }
        }

        // GET: api/TypeCates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TypeCate>> GetTypeCate(int id)
        {
          try
            {
                var typecate = await _repo.TypeCateRepo.GetTypeCateByIdAsync(id);
                if (typecate == null) return NotFound($"Not found typecate has id = {id}");
                return Ok(typecate);
            } catch (Exception ex) { return BadRequest(ex.Message); }
        }

        // PUT: api/TypeCates/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTypeCate(int id, TypeCate typeCate)
        {
           try
            {
                if(id != typeCate.Id) { return BadRequest(typeCate); }
                _repo.TypeCateRepo.UpdateTypeCate(typeCate);
                await _repo.SaveAsync();
                return Ok(typeCate);

            } catch (Exception ex) { return BadRequest(ex.Message); }
        }

        // POST: api/TypeCates
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TypeCate>> PostTypeCate(TypeCate typeCate)
        {
          try
            {
                _repo.TypeCateRepo.CreateTypeCate(typeCate);
                await _repo.SaveAsync();
                return CreatedAtAction("GetTypeCate", new {id = typeCate.Id}, typeCate);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/TypeCates/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTypeCate(int id)
        {
            try
            {
                var typeCate = await _repo.TypeCateRepo.GetTypeCateByIdAsync(id);
                if(typeCate == null) { return NotFound($"Not found typeCate has id = {id}"); }
                _repo.TypeCateRepo.DeleteTypeCate(typeCate);
                await _repo.SaveAsync();
                return Ok($"Deleted typeCate has id = {id} successfully!");
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
