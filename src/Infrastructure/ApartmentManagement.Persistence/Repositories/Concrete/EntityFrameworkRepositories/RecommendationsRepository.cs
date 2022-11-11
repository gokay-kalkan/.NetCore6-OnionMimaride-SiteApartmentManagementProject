

using ApartmentManagement.Application.Repositories.Abstract;
using ApartmentManagement.Domain.Entities;
using ApartmentManagement.Persistence.Contexts;

namespace ApartmentManagement.Persistence.Repositories.Concrete.EntityFrameworkRepositories
{
    public class RecommendationsRepository : GenericRepository<Recommendations, DataContext>, IRecommendationsRepository
    {
        public RecommendationsRepository(DataContext context) : base(context)
        {
        }
    }
}
