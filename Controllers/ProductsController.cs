using Microsoft.AspNetCore.Mvc;
using ThienAspWebApi.Models;
using ThienAspWebApi.Repository.RepositoryWrapper;

namespace ThienAspWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IRepositoryWrapper _repo;

        public ProductsController(IRepositoryWrapper repo)
        {
            _repo = repo;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            try
            {
                var products = await _repo.ProductRepo.GetAllProductsAsync();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            try
            {
                var product = await _repo.ProductRepo.GetProductByIdAsync(id);
                if (product == null) { return NotFound($"not found product has id = {id}"); }
                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            try
            {
                _repo.ProductRepo.CreateProduct(product);
                await _repo.SaveAsync();
                return CreatedAtAction("GetProduct", new { id = product.Id }, product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            try
            {
                if (id != product.Id)
                {
                    return NotFound(product);
                }
                _repo.ProductRepo.UpdateProduct(product);
                await _repo.SaveAsync();
                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                var product = await _repo.ProductRepo.GetProductByIdAsync(id);
                if (product == null) { return NotFound($"Not found category has id = {id}"); }
                _repo.ProductRepo.DeleteProduct(product);
                await _repo.SaveAsync();
                return Ok($"Deleted product has id {id} successfully! ");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
    }
}
