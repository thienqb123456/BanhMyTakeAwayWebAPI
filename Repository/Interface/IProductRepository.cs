using ThienAspWebApi.Models;

namespace ThienAspWebApi.Repository.Interface
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        Task<IEnumerable<Product>> GetAllProductsAsync(string searchString,string orderBy);
        Task<Product> GetProductByIdAsync(int id);

        void CreateProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(Product product);
    }
}
