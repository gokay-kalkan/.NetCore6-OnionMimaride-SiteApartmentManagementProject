

using ApartmentManagement.Application.Features.Users.Models;
using ApartmentManagement.Application.Repositories.Abstract;
using ApartmentManagement.Domain.Entities;
using AutoMapper;
using MediatR;
using NETCore.Encrypt;
using System.Text;

namespace ApartmentManagement.Application.Features.Users.Commands.UserCreateCommand
{
    public class CreateUserCommand:IRequest<UserCreateModel>
    {
        public int UserId { get; set; }

        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public string Password { get; set; }

        public string TcNo { get; set; }

        public bool DeleteStatus { get; set; }
    }
    public class CreateUserCommandHandle : IRequestHandler<CreateUserCommand, UserCreateModel>
    {
        private readonly IUserRepository repository;

        private readonly IMapper mapper;

        public CreateUserCommandHandle(IUserRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<UserCreateModel> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
           var hashedPassword= EncryptProvider.Md5(request.Password);
            request.Password = hashedPassword;
            User user = mapper.Map<User>(request);
            user.DeleteStatus = false;

            User createUser = await repository.AddAsync(user);

            UserCreateModel createdUserModel = mapper.Map<UserCreateModel>(createUser);
            return createdUserModel;
        }
    }

}
