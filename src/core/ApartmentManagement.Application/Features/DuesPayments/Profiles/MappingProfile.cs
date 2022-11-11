

using ApartmentManagement.Application.Features.Dues.Commands.DuesUpdateCommand;
using ApartmentManagement.Application.Features.DuesPayments.Commands.DuesPaymentCreateCommand;
using ApartmentManagement.Application.Features.DuesPayments.Commands.DuesPaymentDeleteCommand;
using ApartmentManagement.Application.Features.DuesPayments.Models;
using ApartmentManagement.Application.Features.DuesPayments.Queries.DuesPaymentListQuery;
using ApartmentManagement.Application.Features.DuesPayments.Queries.GetByIdDuesPayment;
using ApartmentManagement.Domain.Entities;
using AutoMapper;

namespace ApartmentManagement.Application.Features.DuesPayments.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<DuesPayment, DuesListPaymentModel>().ReverseMap();

            CreateMap<DuesPayment, DuesPaymentCreateModel>().ReverseMap();
            CreateMap<DuesPayment, CreateDuesPaymentCommand>().ReverseMap();
            CreateMap<DuesPaymentCreateModel, CreateDuesPaymentCommand>().ReverseMap();

            CreateMap<DuesPayment, DuesPaymentDeleteModel>().ReverseMap();
            CreateMap<DuesPayment, DeleteDuespaymentCommand>().ReverseMap();
            CreateMap<DuesPaymentDeleteModel, DeleteDuespaymentCommand>().ReverseMap();

            CreateMap<DuesPayment, DuesPaymentUpdateModel>().ReverseMap();
            CreateMap<DuesPayment, UpdateDuesCommand>().ReverseMap();
            CreateMap<DuesPaymentUpdateModel, UpdateDuesCommand>().ReverseMap();


            CreateMap<DuesPayment, DuesPaymentGetByIdModel>().ReverseMap();
            CreateMap<DuesPayment, GetByIdDuesPaymentQuery>().ReverseMap();
            CreateMap<DuesPaymentGetByIdModel, GetByIdDuesPaymentQuery>().ReverseMap();

        }
    }
}
