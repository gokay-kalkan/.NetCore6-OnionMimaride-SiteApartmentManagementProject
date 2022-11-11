

using ApartmentManagement.Application.Features.Dues.Commands.DuesCreateCommand;
using ApartmentManagement.Application.Features.Dues.Commands.DuesDeleteCommand;
using ApartmentManagement.Application.Features.Dues.Commands.DuesPaidStatusUpdateCommand;
using ApartmentManagement.Application.Features.Dues.Commands.DuesUpdateCommand;
using ApartmentManagement.Application.Features.Dues.Models;
using ApartmentManagement.Application.Features.Dues.Queries.DuesListQuery;
using ApartmentManagement.Application.Features.Dues.Queries.GetByIdDues;
using AutoMapper;

namespace ApartmentManagement.Application.Features.Dues.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Domain.Entities.Dues, DuesListModel>().ReverseMap();
           

            CreateMap<Domain.Entities.Dues, DuesCreateModel>().ReverseMap();
            CreateMap<Domain.Entities.Dues, CreateDuesCommand>().ReverseMap();
            CreateMap<DuesCreateModel, CreateDuesCommand>().ReverseMap();

            CreateMap<Domain.Entities.Dues, DuesGetByIdModel>().ReverseMap();
            CreateMap<Domain.Entities.Dues, GetByIdDuesQuery>().ReverseMap();
            CreateMap<DuesGetByIdModel, GetByIdDuesQuery>().ReverseMap();

            CreateMap<Domain.Entities.Dues, DuesDeleteModel>().ReverseMap();
            CreateMap<Domain.Entities.Dues, DeleteDuesCommand>().ReverseMap();
            CreateMap<DuesDeleteModel, DeleteDuesCommand>().ReverseMap();

            CreateMap<Domain.Entities.Dues, DuesUpdateModel>().ReverseMap();
            CreateMap<Domain.Entities.Dues, UpdateDuesCommand>().ReverseMap();
            CreateMap<DuesUpdateModel, UpdateDuesCommand>().ReverseMap();

            CreateMap<Domain.Entities.Dues, DuesPaidStatusUpdateModel>().ReverseMap();
            CreateMap<Domain.Entities.Dues, UpdateDuesPaidStatusCommand>().ReverseMap();
            CreateMap<DuesPaidStatusUpdateModel, UpdateDuesPaidStatusCommand>().ReverseMap();

        }
    }
}
