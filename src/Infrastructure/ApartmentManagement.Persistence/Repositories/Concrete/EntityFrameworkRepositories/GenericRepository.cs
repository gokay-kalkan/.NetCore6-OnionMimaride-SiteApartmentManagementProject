

using ApartmentManagement.Application.Repositories.Abstract;
using ApartmentManagement.Persistence.Contexts;

using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq;

namespace ApartmentManagement.Persistence.Repositories.Concrete.EntityFrameworkRepositories
{
    public class GenericRepository<T, TContext> : IGenericRepository<T> where T : class, new() where TContext : DataContext
    {
        private DataContext context;
        DbSet<T> _object;

        public GenericRepository(DataContext context)
        {
            this.context = context;
            _object = context.Set<T>();

        }
        public async Task Add(T p)
        {

            _object.Add(p);
            await context.SaveChangesAsync();
        }

        public void Delete(T p)
        {
           
            _object.Remove(p);
            context.SaveChanges();
        }

        public List<T> GetAll()
        {
            return _object.ToList();
        }

        public IQueryable<T> Query()
        {
            return context.Set<T>();
        }
        public List<T> GetAll(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }

        public T GetOne(int id)
        {
            return _object.Find(id);
        }

        public async Task Update(T p)
        {
            
            context.Entry<T>(p).State = EntityState.Modified;
          

            await context.SaveChangesAsync();
        }



        public async Task<T> AddAsync(T entity)
        {
            _object.Add(entity);
            await context.SaveChangesAsync();

            return entity;
        }

      
    }
}
