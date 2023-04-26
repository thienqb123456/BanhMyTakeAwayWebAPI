using ThienAspWebApi.Repository.Interface;

namespace ThienAspWebApi.Repository.RepositoryWrapper
{
    public interface IRepositoryWrapper
    {
        ICategoryRepository CategoryRepo { get; }

        ITypeCateRepository TypeCateRepo { get; }

        IProductRepository ProductRepo { get; }

        Task SaveAsync();
    }
}
