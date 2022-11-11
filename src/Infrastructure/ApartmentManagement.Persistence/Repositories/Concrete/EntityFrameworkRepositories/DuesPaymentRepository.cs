
using ApartmentManagement.Application.Repositories.Abstract;
using ApartmentManagement.Domain.Entities;
using ApartmentManagement.Persistence.Contexts;

namespace ApartmentManagement.Persistence.Repositories.Concrete.EntityFrameworkRepositories
{
    public class DuesPaymentRepository : GenericRepository<DuesPayment, DataContext>, IDuesPaymentRepository
    {
        public DuesPaymentRepository(DataContext context) : base(context)
        {
        }
    }
}
