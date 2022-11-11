

using ApartmentManagement.Application.Features.Dues.Models;
using ApartmentManagement.Application.Features.Dues.Queries.GetByIdDues;
using ApartmentManagement.Application.Features.DuesPayments.Models;
using ApartmentManagement.Application.Repositories.Abstract;
using AutoMapper;
using MediatR;

namespace ApartmentManagement.Application.Features.DuesPayments.Queries.GetByIdDuesPayment
{
    public class GetByIdDuesPaymentQuery : IRequest<DuesPaymentGetByIdModel>
    {
        public int DuesPaymentId { get; set; }

        public int UserId { get; set; }

        public double PaymentAmount { get; set; }

        public DateTime PaymentDate { get; set; }
    }

    public class GetByIdDuesPaymentQueryHandle : IRequestHandler<GetByIdDuesPaymentQuery, DuesPaymentGetByIdModel>
    {
        private readonly IDuesPaymentRepository repository;

        private readonly IMapper mapper;

        public GetByIdDuesPaymentQueryHandle(IDuesPaymentRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<DuesPaymentGetByIdModel> Handle(GetByIdDuesPaymentQuery request, CancellationToken cancellationToken)
        {
            var duesPayment = repository.GetOne(request.DuesPaymentId);

            //_brandBusinessRules.BrandShouldExistWhenRequested(brand);

            DuesPaymentGetByIdModel duesPaymentModel = mapper.Map<DuesPaymentGetByIdModel>(duesPayment);
            return duesPaymentModel;
        }
    }
}
