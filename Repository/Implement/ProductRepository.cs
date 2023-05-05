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

        public async Task<IEnumerable<Product>> GetAllProductsAsync(string searchString, string orderBy)
        {
            var productsQr = FindAll().OrderByDescending(p=>p.TimeCreated)
                                      .AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                productsQr = productsQr.Where(p => p.Name!.Contains(searchString)
                                                || p.Description!.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(orderBy))
            {
                switch (orderBy)
                {
                    case "price":
                        productsQr = productsQr.OrderBy(p => p.Price);
                        break;
                    case "price_desc":
                        productsQr = productsQr.OrderByDescending(p => p.Price);
                        break;
                    case "name":
                        productsQr = productsQr.OrderBy(p => p.Name);
                        break;
                    case "name_desc":
                        productsQr = productsQr.OrderByDescending(p => p.Name);
                        break;
                    default:
                        productsQr = productsQr.OrderBy(p => p.TimeCreated);
                        break;
                }
            }

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
