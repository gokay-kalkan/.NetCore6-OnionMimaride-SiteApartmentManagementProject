

using ApartmentManagement.Application.Features.Managers.Commands.ManagerLogin;
using ApartmentManagement.Application.Features.Managers.Models;
using ApartmentManagement.Domain.Entities;
using AutoMapper;

namespace ApartmentManagement.Application.Features.Managers.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Manager, LoginModel>().ReverseMap();
            CreateMap<Manager, ManagerLoginCommand>().ReverseMap();
            CreateMap<LoginModel, ManagerLoginCommand>().ReverseMap();
        }
    }
}
