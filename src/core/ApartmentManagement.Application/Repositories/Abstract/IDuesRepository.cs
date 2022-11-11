

using ApartmentManagement.Domain.Entities;
using System.Linq.Expressions;

namespace ApartmentManagement.Application.Repositories.Abstract
{
    public interface IDuesRepository : IGenericRepository<Dues>
    {
        public Task DuesPaidStatusUpdate(Dues p);
   
    }
}
