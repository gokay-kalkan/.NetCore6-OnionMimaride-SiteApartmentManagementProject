

using ApartmentManagement.Application.Features.Circles.Models;
using ApartmentManagement.Application.Features.Users.Commands.UserCreateCommand;
using ApartmentManagement.Application.Features.Users.Models;
using ApartmentManagement.Application.Repositories.Abstract;
using ApartmentManagement.Domain.Entities;
using AutoMapper;
using MediatR;
using NETCore.Encrypt;

namespace ApartmentManagement.Application.Features.Circles.Commands.CircleCreateCommand
{
    public class CreateCircleCommand:IRequest<CircleCreateModel>
    {
        public int CircleId { get; set; }

        public string CircleNo { get; set; }

        public int UserId { get; set; }

        public string TenantOwner { get; set; }

        public int LivingPeopleCount { get; set; }

    }

    public class CreateCircleCommandHandle : IRequestHandler<CreateCircleCommand, CircleCreateModel>
    {
        private readonly ICircleRepository repository;

        private readonly IMapper mapper;

        public CreateCircleCommandHandle(ICircleRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<CircleCreateModel> Handle(CreateCircleCommand request, CancellationToken cancellationToken)
        {
          
            Circle circle = mapper.Map<Circle>(request);
            circle.DeleteStatus = false;

            Circle createCircle = await repository.AddAsync(circle);

            CircleCreateModel createdCircleModel = mapper.Map<CircleCreateModel>(createCircle);
            return createdCircleModel;
        }
    }
}
