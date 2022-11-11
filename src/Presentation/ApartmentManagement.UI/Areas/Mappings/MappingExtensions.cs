using ApartmentManagement.UI.Areas.Manager.Models;
using AutoMapper;

namespace ApartmentManagement.UI.Areas.Mappings
{
    public class MappingExtensions:Profile
    {
        public MappingExtensions()
        {
            CreateMap<Domain.Entities.Manager, LoginViewModel>().ReverseMap();
        }
    }
}
