

using ApartmentManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApartmentManagement.Persistence.Contexts
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Circle> Circles { get; set; }
   
        public DbSet<Dues> Dues { get; set; }
        public DbSet<DuesPayment> DuesPayments { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Recommendations> Recommendations { get; set; }
    }
}
