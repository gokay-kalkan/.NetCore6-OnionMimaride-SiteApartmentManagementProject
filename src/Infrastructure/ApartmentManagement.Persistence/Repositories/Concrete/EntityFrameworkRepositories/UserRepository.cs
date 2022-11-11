

using ApartmentManagement.Application.Repositories.Abstract;
using ApartmentManagement.Domain.Entities;
using ApartmentManagement.Persistence.Contexts;
using Microsoft.AspNetCore.Authentication;

using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using NETCore.Encrypt;
using System.Linq.Expressions;

namespace ApartmentManagement.Persistence.Repositories.Concrete.EntityFrameworkRepositories
{
    public class UserRepository : GenericRepository<User, DataContext>, IUserRepository
    {
        private DataContext context;
        public UserRepository(DataContext context) : base(context)
        {
            this.context = context;
        }

       
    }
}
