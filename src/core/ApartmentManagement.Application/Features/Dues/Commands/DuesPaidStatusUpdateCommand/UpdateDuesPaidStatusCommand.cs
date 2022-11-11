

using ApartmentManagement.Application.Features.Dues.Commands.DuesUpdateCommand;
using ApartmentManagement.Application.Features.Dues.Models;
using ApartmentManagement.Application.Repositories.Abstract;
using AutoMapper;
using MediatR;

namespace ApartmentManagement.Application.Features.Dues.Commands.DuesPaidStatusUpdateCommand
{
    public class UpdateDuesPaidStatusCommand : IRequest<DuesPaidStatusUpdateModel>
    {
        public int DuesId { get; set; }

        public string? DuesType { get; set; }

        public int? CircleId { get; set; }

        public int? UserId { get; set; }

        public double? DuesPrice { get; set; }
        public bool PaidStatus { get; set; }

        public DateTime? PaymentDate { get; set; }

        public DateTime PaymentDeadline { get; set; }

    }

    public class UpdateDuesPaidStatusCommandHandle : IRequestHandler<UpdateDuesPaidStatusCommand, DuesPaidStatusUpdateModel>
    {
        private readonly IDuesRepository repository;

        private readonly IMapper mapper;

        public UpdateDuesPaidStatusCommandHandle(IDuesRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<DuesPaidStatusUpdateModel> Handle(UpdateDuesPaidStatusCommand request, CancellationToken cancellationToken)
        {
            var dto = mapper.Map<Domain.Entities.Dues>(request);

            await repository.DuesPaidStatusUpdate(dto);
            DuesPaidStatusUpdateModel updateDuesModel = mapper.Map<DuesPaidStatusUpdateModel>(dto);

            return updateDuesModel;
        }
    }
}
