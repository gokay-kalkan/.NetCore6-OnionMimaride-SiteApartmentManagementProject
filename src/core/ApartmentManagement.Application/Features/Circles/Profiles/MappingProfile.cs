

using ApartmentManagement.Application.Features.Circles.Commands.CircleCreateCommand;
using ApartmentManagement.Application.Features.Circles.Commands.CircleDeleteCommand;
using ApartmentManagement.Application.Features.Circles.Commands.CircleUpdateCommand;
using ApartmentManagement.Application.Features.Circles.Models;
using ApartmentManagement.Application.Features.Circles.Queries.GetByIdCircle;
using ApartmentManagement.Domain.Entities;
using AutoMapper;

namespace ApartmentManagement.Application.Features.Circles.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Circle, CircleListModel>().ReverseMap();
            CreateMap<Circle, CircleGetByIdModel>().ReverseMap();
            CreateMap<Circle, GetByIdCircleQuery>().ReverseMap();
            CreateMap<CircleGetByIdModel, GetByIdCircleQuery>().ReverseMap();
            CreateMap<Circle, CreateCircleCommand>().ReverseMap();
            CreateMap<Circle, CircleCreateModel>().ReverseMap();
            CreateMap<CreateCircleCommand, CircleCreateModel>().ReverseMap();
            CreateMap<DeleteCircleCommand, DeleteCircleModel>().ReverseMap();
            CreateMap<DeleteCircleCommand, Circle>().ReverseMap();
            CreateMap<DeleteCircleModel, Circle>().ReverseMap();
            CreateMap<CircleUpdateModel, Circle>().ReverseMap();
            CreateMap<UpdateCircleCommand, Circle>().ReverseMap();
            CreateMap<UpdateCircleCommand, CircleUpdateModel>().ReverseMap();
        }
    }
}
