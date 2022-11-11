

using ApartmentManagement.Application.Features.Circles.Commands.CircleUpdateCommand;
using ApartmentManagement.Application.Features.Circles.Models;
using ApartmentManagement.Application.Features.Dues.Models;
using ApartmentManagement.Application.Repositories.Abstract;
using ApartmentManagement.Domain.Entities;
using AutoMapper;
using MediatR;

namespace ApartmentManagement.Application.Features.Dues.Commands.DuesUpdateCommand
{
    public class UpdateDuesCommand : IRequest<DuesUpdateModel>
    {
        public int DuesId { get; set; }

        public string? DuesType { get; set; }

        public int? CircleId { get; set; }

        public int? UserId { get; set; }

        public double? DuesPrice { get; set; }
        public bool PaidStatus { get; set; }

        public DateTime? PaymentDate { get; set; }

    }

    public class UpdateDuesCommandHandle : IRequestHandler<UpdateDuesCommand, DuesUpdateModel>
    {
        private readonly IDuesRepository repository;

        private readonly IMapper mapper;

        public UpdateDuesCommandHandle(IDuesRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<DuesUpdateModel> Handle(UpdateDuesCommand request, CancellationToken cancellationToken)
        {
            var dto = mapper.Map<Domain.Entities.Dues>(request);

            await repository.Update(dto);
            DuesUpdateModel updateDuesModel = mapper.Map<DuesUpdateModel>(dto);
           
            return updateDuesModel;
        }
    }
}
