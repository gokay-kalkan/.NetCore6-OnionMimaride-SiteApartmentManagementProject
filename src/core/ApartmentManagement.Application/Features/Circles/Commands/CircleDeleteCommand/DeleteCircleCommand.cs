
using ApartmentManagement.Application.Features.Circles.Models;
using ApartmentManagement.Application.Features.Users.Commands.UserDeleteCommand;
using ApartmentManagement.Application.Features.Users.Models;
using ApartmentManagement.Application.Repositories.Abstract;
using AutoMapper;
using MediatR;

namespace ApartmentManagement.Application.Features.Circles.Commands.CircleDeleteCommand
{
    public class DeleteCircleCommand : IRequest<DeleteCircleModel>
    {
        public int CircleId { get; set; }

    }

    public class DeleteCircleCommandHandle : IRequestHandler<DeleteCircleCommand, DeleteCircleModel>
    {
        private readonly ICircleRepository repository;

        private readonly IMapper mapper;

        public DeleteCircleCommandHandle(ICircleRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<DeleteCircleModel> Handle(DeleteCircleCommand request, CancellationToken cancellationToken)
        {
            var circle = repository.GetOne(request.CircleId);
            circle.DeleteStatus = true;
            repository.Update(circle);

            var dto = mapper.Map<DeleteCircleModel>(circle);

            return dto;
        }
    }
}
