
using System.Linq.Expressions;

namespace ApartmentManagement.Application.Repositories.Abstract
{
    public interface IGenericRepository<T>
    {
        public List<T> GetAll();
        public List<T> GetAll(Expression<Func<T, bool>> filter);

      
        public T GetOne(int id);

        public Task Add(T p);

        Task<T> AddAsync(T entity);
        public Task Update(T p);
        public void Delete(T p);
      
    }
}
