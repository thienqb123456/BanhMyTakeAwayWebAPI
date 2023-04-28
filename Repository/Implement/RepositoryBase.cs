using System.Linq.Expressions;
using ThienAspWebApi.Database;
using ThienAspWebApi.Repository.Interface;

namespace ThienAspWebApi.Repository.Implement
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private protected AppStoreContext _context { get; set; }

        public RepositoryBase(AppStoreContext context)
        {
            _context = context;
        }

        public IQueryable<T> FindAll()
        {
            return _context.Set<T>();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression);
        }
        public void Create(T entity)
        {
            _context.Set<T>().Add(entity);
        }
        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity); 
        }

    
    }
}
