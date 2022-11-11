

using ApartmentManagement.Application.Features.Circles.Models;
using ApartmentManagement.Application.Features.Users.Commands.UserUpdateCommand;
using ApartmentManagement.Application.Features.Users.Models;
using ApartmentManagement.Application.Repositories.Abstract;
using ApartmentManagement.Domain.Entities;
using AutoMapper;
using MediatR;

namespace ApartmentManagement.Application.Features.Circles.Commands.CircleUpdateCommand
{
    public class UpdateCircleCommand:IRequest<CircleUpdateModel>
    {
        public int CircleId { get; set; }

        public string CircleNo { get; set; }

        public int UserId { get; set; }

        public string TenantOwner { get; set; }

        public int LivingPeopleCount { get; set; }
    }

    public class UpdateCircleCommandHandle : IRequestHandler<UpdateCircleCommand, CircleUpdateModel>
    {
        private readonly ICircleRepository repository;

        private readonly IMapper mapper;

        public UpdateCircleCommandHandle(ICircleRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<CircleUpdateModel> Handle(UpdateCircleCommand request, CancellationToken cancellationToken)
        {
            var dto = mapper.Map<Circle>(request);
            await repository.Update(dto);

            CircleUpdateModel updateCircleModel = mapper.Map<CircleUpdateModel>(dto);

            return updateCircleModel;
        }
    }
}
