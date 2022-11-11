

using ApartmentManagement.Application.Features.Managers.Models;
using ApartmentManagement.Domain.Entities;

namespace ApartmentManagement.Application.Repositories.Abstract
{
    public interface IManagerRepository:IGenericRepository<Manager>
    {
        public void LoginManager(LoginModel model);

        public string ManagerFullName();
    }
}
