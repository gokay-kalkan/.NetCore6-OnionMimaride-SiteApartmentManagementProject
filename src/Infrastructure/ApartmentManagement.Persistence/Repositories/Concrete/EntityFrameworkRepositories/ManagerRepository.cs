

using ApartmentManagement.Application.Features.Managers.Models;
using ApartmentManagement.Application.Repositories.Abstract;
using ApartmentManagement.Domain.Entities;
using ApartmentManagement.Persistence.Contexts;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using NETCore.Encrypt;
using System.Security.Claims;

namespace ApartmentManagement.Persistence.Repositories.Concrete.EntityFrameworkRepositories
{
    public class ManagerRepository : GenericRepository<Manager, DataContext>, IManagerRepository
    {
        private DataContext context;

        public ManagerRepository(DataContext context) : base(context)
        {
            this.context = context;

        }
        public void LoginManager(LoginModel model)
        {
            var dataValue = context.Managers.FirstOrDefault(x => x.Email == model.Email && x.Password == model.Password);
        }

        public string ManagerFullName()
        {
            var fullname=context.Managers.Select(x => x.FullName).First();
            return fullname;
        }
    }
}
