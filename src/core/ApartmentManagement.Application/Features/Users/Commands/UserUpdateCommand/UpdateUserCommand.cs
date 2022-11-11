

using ApartmentManagement.Application.Features.Users.Models;
using ApartmentManagement.Application.Repositories.Abstract;
using ApartmentManagement.Domain.Entities;
using AutoMapper;
using MediatR;

namespace ApartmentManagement.Application.Features.Users.Commands.UserUpdateCommand
{
    public class UpdateUserCommand:IRequest<UpdateUserModel>
    {
        public int UserId { get; set; }

        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public string TcNo { get; set; }
        public string? Password { get; set; }

    }
    public class UpdateUserCommandHandle : IRequestHandler<UpdateUserCommand, UpdateUserModel>
    {
        private readonly IUserRepository repository;

        private readonly IMapper mapper;

        public UpdateUserCommandHandle(IUserRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<UpdateUserModel> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var dto = mapper.Map<User>(request);
           
           
           await repository.Update(dto);
            
           

            UpdateUserModel updateUserModel = mapper.Map<UpdateUserModel>(dto);

            return updateUserModel;
        }
    }

}
