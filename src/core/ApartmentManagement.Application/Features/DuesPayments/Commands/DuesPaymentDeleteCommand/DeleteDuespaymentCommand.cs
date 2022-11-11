

using ApartmentManagement.Application.Features.Dues.Commands.DuesDeleteCommand;
using ApartmentManagement.Application.Features.Dues.Models;
using ApartmentManagement.Application.Features.DuesPayments.Models;
using ApartmentManagement.Application.Repositories.Abstract;
using AutoMapper;
using MediatR;

namespace ApartmentManagement.Application.Features.DuesPayments.Commands.DuesPaymentDeleteCommand
{
    public class DeleteDuespaymentCommand : IRequest<DuesPaymentDeleteModel>
    {
        public int DuesPaymentId { get; set; }
    }

    public class DeleteDuespaymentCommandHandle : IRequestHandler<DeleteDuespaymentCommand, DuesPaymentDeleteModel>
    {
        private readonly IDuesPaymentRepository repository;

        private readonly IMapper mapper;

        public DeleteDuespaymentCommandHandle(IDuesPaymentRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<DuesPaymentDeleteModel> Handle(DeleteDuespaymentCommand request, CancellationToken cancellationToken)
        {
            var duesPayment = repository.GetOne(request.DuesPaymentId);
            duesPayment.DeleteStatus = true;
            repository.Update(duesPayment);

            var dto = mapper.Map<DuesPaymentDeleteModel>(duesPayment);

            return dto;
        }
    }
}
