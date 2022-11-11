

using ApartmentManagement.Application.Features.Users.Models;
using ApartmentManagement.Application.Repositories.Abstract;
using AutoMapper;
using MediatR;

namespace ApartmentManagement.Application.Features.Users.Commands.UserDeleteCommand
{
    public class DeleteUserCommand:IRequest<DeleteUserModel>
    {
        public int UserId { get; set; }
    }
    public class DeleteUserCommandHandle : IRequestHandler<DeleteUserCommand, DeleteUserModel>
    {
        private readonly IUserRepository repository;

        private readonly IMapper mapper;

        public DeleteUserCommandHandle(IUserRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<DeleteUserModel> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = repository.GetOne(request.UserId);
            user.DeleteStatus = true;
            repository.Update(user);

            var dto = mapper.Map<DeleteUserModel>(user);

            return dto;
        }
    }

}
