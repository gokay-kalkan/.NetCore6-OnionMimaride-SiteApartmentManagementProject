
using ApartmentManagement.Application.Features.Dues.Models;
using ApartmentManagement.Application.Features.Dues.Queries.DuesListQuery;
using ApartmentManagement.Application.Features.DuesPayments.Models;
using ApartmentManagement.Application.Repositories.Abstract;
using AutoMapper;
using MediatR;

namespace ApartmentManagement.Application.Features.DuesPayments.Queries.DuesPaymentListQuery
{
    public class ListDuesPaymentQuery : IRequest<List<DuesListPaymentModel>>
    {

    }

    public class ListDuesPaymentQueryHandle : IRequestHandler<ListDuesPaymentQuery, List<DuesListPaymentModel>>
    {
        private readonly IDuesPaymentRepository repository;

        private readonly IMapper mapper;

        public ListDuesPaymentQueryHandle(IDuesPaymentRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<List<DuesListPaymentModel>> Handle(ListDuesPaymentQuery request, CancellationToken cancellationToken)
        {
            var duesPayment = repository.GetAll(x => x.DeleteStatus == false);

            var mapping = mapper.Map<List<DuesListPaymentModel>>(duesPayment);

            return mapping;
        }
    }
}
