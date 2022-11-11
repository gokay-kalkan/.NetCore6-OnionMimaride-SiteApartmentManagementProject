

using ApartmentManagement.Application.Repositories.Abstract;
using ApartmentManagement.Persistence.Contexts;
using ApartmentManagement.Persistence.Repositories.Concrete.EntityFrameworkRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ApartmentManagement.Persistence.Registirations
{
    public static class ServiceRegistirations
    {
        public static void RegistrationServicePersistence(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<ICircleRepository, CircleRepositories>();
           
            services.AddScoped<IDuesPaymentRepository, DuesPaymentRepository>();
            services.AddScoped<IDuesRepository, DuesRepository>();
            services.AddScoped<IRecommendationsRepository, RecommendationsRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IManagerRepository, ManagerRepository>();

            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")).UseLazyLoadingProxies();
                
            });
        }
    }
}
