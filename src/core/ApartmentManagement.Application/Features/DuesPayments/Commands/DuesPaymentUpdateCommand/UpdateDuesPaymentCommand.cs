

using ApartmentManagement.Application.Features.Dues.Commands.DuesUpdateCommand;
using ApartmentManagement.Application.Features.Dues.Models;
using ApartmentManagement.Application.Features.DuesPayments.Models;
using ApartmentManagement.Application.Repositories.Abstract;
using AutoMapper;
using MediatR;

namespace ApartmentManagement.Application.Features.DuesPayments.Commands.DuesPaymentUpdateCommand
{
    public class UpdateDuesPaymentCommand : IRequest<DuesPaymentUpdateModel>
    {
        public int DuesPaymentId { get; set; }

        public int UserId { get; set; }

        public double PaymentAmount { get; set; }

        public DateTime PaymentDate { get; set; }

        public string CardNumber { get; set; }

        public string CardName { get; set; }

        public string ExpirationMonth { get; set; }

        public string ExpirationYear { get; set; }

        public string Cvc { get; set; }
    }

    public class UpdateDuesPaymentCommandHandle : IRequestHandler<UpdateDuesPaymentCommand, DuesPaymentUpdateModel>
    {
        private readonly IDuesPaymentRepository repository;

        private readonly IMapper mapper;

        public UpdateDuesPaymentCommandHandle(IDuesPaymentRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<DuesPaymentUpdateModel> Handle(UpdateDuesPaymentCommand request, CancellationToken cancellationToken)
        {
            var dto = mapper.Map<Domain.Entities.DuesPayment>(request);
            await repository.Update(dto);

            DuesPaymentUpdateModel updateDuesPaymentModel = mapper.Map<DuesPaymentUpdateModel>(dto);

            return updateDuesPaymentModel;
        }
    }
}
