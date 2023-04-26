using Microsoft.EntityFrameworkCore;
using ThienAspWebApi.Database;
using ThienAspWebApi.Models;
using ThienAspWebApi.Repository.Interface;

namespace ThienAspWebApi.Repository.Implement
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository 
    {
        public CategoryRepository(AppStoreContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            var categoriesQr = FindAll()
                                        .AsQueryable();
            return await categoriesQr.ToListAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            var category = await FindByCondition(cate => cate.Id == id).FirstOrDefaultAsync();
            return category!;
        }

        public void CreateCategory(Category category)
        {
            Create(category);
        }
        public void UpdateCategory(Category category)
        {
            Update(category);
        }

        public void DeleteCategory(Category category)
        {
            Delete(category);
        }




    }
}
