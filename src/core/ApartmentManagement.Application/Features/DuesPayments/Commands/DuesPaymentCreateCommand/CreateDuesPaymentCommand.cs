

using ApartmentManagement.Application.Features.Dues.Commands.DuesCreateCommand;
using ApartmentManagement.Application.Features.Dues.Models;
using ApartmentManagement.Application.Features.DuesPayments.Models;
using ApartmentManagement.Application.Repositories.Abstract;
using AutoMapper;
using MediatR;

namespace ApartmentManagement.Application.Features.DuesPayments.Commands.DuesPaymentCreateCommand
{
    public class CreateDuesPaymentCommand : IRequest<DuesPaymentCreateModel>
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

    public class CreateDuesPaymentCommandHandle : IRequestHandler<CreateDuesPaymentCommand, DuesPaymentCreateModel>
    {
        private readonly IDuesPaymentRepository repository;

        private readonly IMapper mapper;

        public CreateDuesPaymentCommandHandle(IDuesPaymentRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<DuesPaymentCreateModel> Handle(CreateDuesPaymentCommand request, CancellationToken cancellationToken)
        {

            var duesPayment = mapper.Map<Domain.Entities.DuesPayment>(request);
            duesPayment.DeleteStatus = false;
            duesPayment.PaymentDate = DateTime.Now;

            Domain.Entities.DuesPayment createPaymentDues = await repository.AddAsync(duesPayment);

            DuesPaymentCreateModel createdDuesPaymentModel = mapper.Map<DuesPaymentCreateModel>(createPaymentDues);
            return createdDuesPaymentModel;
        }
    }
}
