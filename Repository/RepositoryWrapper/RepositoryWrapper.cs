using ThienAspWebApi.Database;
using ThienAspWebApi.Repository.Implement;
using ThienAspWebApi.Repository.Interface;

namespace ThienAspWebApi.Repository.RepositoryWrapper
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private  AppStoreContext _context;
        private  ICategoryRepository _categoryRepo;
        private  ITypeCateRepository _typeCateRepo;
        private  IProductRepository _productRepo;


        public ICategoryRepository CategoryRepo
        {
            get
            {
                if (_categoryRepo == null)
                {
                    _categoryRepo = new CategoryRepository(_context);
                }
                return _categoryRepo;
            }
        }

        public ITypeCateRepository TypeCateRepo
        {
            get
            {
                if (_typeCateRepo == null)
                {
                    _typeCateRepo = new TypeCateRepository(_context);
                }
                return _typeCateRepo;
            }
        }
        public IProductRepository ProductRepo
        {
            get
            {
                if (_productRepo == null)
                {
                    _productRepo = new ProductRepository(_context);
                }
                return _productRepo;
            }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public RepositoryWrapper(AppStoreContext context)
        {
            _context = context;
            _categoryRepo = CategoryRepo;
            _typeCateRepo = TypeCateRepo;
            _productRepo = ProductRepo;
        }

    }
}
