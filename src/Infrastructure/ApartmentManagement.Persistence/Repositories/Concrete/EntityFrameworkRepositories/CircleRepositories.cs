

using ApartmentManagement.Application.Repositories.Abstract;
using ApartmentManagement.Domain.Entities;
using ApartmentManagement.Persistence.Contexts;

namespace ApartmentManagement.Persistence.Repositories.Concrete.EntityFrameworkRepositories
{
    public class CircleRepositories : GenericRepository<Circle, DataContext>, ICircleRepository
    {
        public CircleRepositories(DataContext context) : base(context)
        {

        }
    }
}
