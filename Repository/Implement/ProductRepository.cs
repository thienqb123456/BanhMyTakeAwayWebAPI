using Microsoft.EntityFrameworkCore;
using ThienAspWebApi.Database;
using ThienAspWebApi.Models;
using ThienAspWebApi.Repository.Interface;

namespace ThienAspWebApi.Repository.Implement
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(AppStoreContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            var productsQr = FindAll().AsQueryable();
            return await productsQr.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var product = await FindByCondition(p => p.Id == id).FirstOrDefaultAsync();
            return product!;
        }

        public void CreateProduct(Product product)
        {
            Create(product);
        }

        public void UpdateProduct(Product product)
        {
            Update(product);
        }


        public void DeleteProduct(Product product)
        {
            Delete(product);
        }

        
    }
}
