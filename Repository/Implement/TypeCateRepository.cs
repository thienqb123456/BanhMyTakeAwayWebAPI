using Microsoft.EntityFrameworkCore;
using ThienAspWebApi.Database;
using ThienAspWebApi.Models;
using ThienAspWebApi.Repository.Interface;

namespace ThienAspWebApi.Repository.Implement
{
    public class TypeCateRepository : RepositoryBase<TypeCate>, ITypeCateRepository
    {
        public TypeCateRepository(AppStoreContext context) : base(context)
        {
        }

        public async Task<IEnumerable<TypeCate>> GetAllTypeCatesAsync()
        {
            var typeCatesQr = FindAll().AsQueryable();
            return await typeCatesQr.ToListAsync(); 
        }

        public async Task<TypeCate> GetTypeCateByIdAsync(int id)
        {
            var typeCate = await FindByCondition(type => type.Id == id).FirstOrDefaultAsync();
            return typeCate!;
        }

        public void CreateTypeCate(TypeCate typeCate)
        {
            Create(typeCate);
        }

        public void UpdateTypeCate(TypeCate typeCate)
        {
            Update(typeCate);
        }

        public void DeleteTypeCate(TypeCate typeCate)
        {
            Delete(typeCate);
        }

 
    }
}
