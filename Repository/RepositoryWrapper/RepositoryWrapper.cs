using ThienAspWebApi.Database;
using ThienAspWebApi.Repository.Interface;

namespace ThienAspWebApi.Repository.RepositoryWrapper
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly AppStoreContext _context;
        private readonly ICategoryRepository _categoryRepo;
        private readonly ITypeCateRepository _typeCateRepo;
        private readonly IProductRepository _productRepo;

        public ICategoryRepository CategoryRepo { get { return _categoryRepo; } }

        public ITypeCateRepository TypeCateRepo { get { return _typeCateRepo; } }

        public IProductRepository ProductRepo { get { return _productRepo; } }

        public RepositoryWrapper(AppStoreContext context)
        {
            _context = context;
            _categoryRepo = CategoryRepo;
            _productRepo = ProductRepo;
            _typeCateRepo = TypeCateRepo;

        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
