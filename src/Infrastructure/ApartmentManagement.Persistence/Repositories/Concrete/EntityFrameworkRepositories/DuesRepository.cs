
using ApartmentManagement.Application.Repositories.Abstract;
using ApartmentManagement.Domain.Entities;
using ApartmentManagement.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ApartmentManagement.Persistence.Repositories.Concrete.EntityFrameworkRepositories
{
    public class DuesRepository : GenericRepository<Dues, DataContext>, IDuesRepository
    {
        private DataContext context;
        public DuesRepository(DataContext context) : base(context)
        {
            this.context = context;
        }

       
        public async Task DuesPaidStatusUpdate(Dues p)
        {
            var dues = context.Dues.FirstOrDefault(x => x.DuesId == p.DuesId);
            dues.PaidStatus = true;
            context.Entry(dues).State = EntityState.Modified;
            
          
            await context.SaveChangesAsync();
           

        }
    }
}
