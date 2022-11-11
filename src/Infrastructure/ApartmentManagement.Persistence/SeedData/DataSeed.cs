
using ApartmentManagement.Domain.Entities;
using ApartmentManagement.Persistence.Contexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using NETCore.Encrypt;

namespace ApartmentManagement.Persistence.SeedData
{
    public static class DataSeed
    {
        public static async Task<IApplicationBuilder> PrepareDatabase(this IApplicationBuilder app)
        {
            using var scopedService = app.ApplicationServices.CreateScope();

            var serviceProvider = scopedService.ServiceProvider;

            await Seed(serviceProvider);

            return app;
        }

        public static async Task Seed(this IServiceProvider serviceProvider)
        {

            var managervalue = new Manager();

            var dbcontext = serviceProvider.GetRequiredService<DataContext>();

            managervalue.FullName = "Yönetici Gökay";
            managervalue.PhoneNumber = "1234567890";
            managervalue.Email = "gokay@mail.com";
            var password="manager123456";

            var hashedPassword=EncryptProvider.Md5(password);

            managervalue.Password = hashedPassword;

          

            dbcontext.Add(managervalue);
            dbcontext.SaveChanges();




        }
    }
}
