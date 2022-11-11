

using ApartmentManagement.Application.Features.Users.Commands.UserCreateCommand;
using ApartmentManagement.Application.Features.Users.Commands.UserDeleteCommand;
using ApartmentManagement.Application.Features.Users.Commands.UserUpdateCommand;
using ApartmentManagement.Application.Features.Users.Models;
using ApartmentManagement.Application.Features.Users.Queries.GetByIdUser;
using ApartmentManagement.Application.Features.Users.Queries.UserListQuery;
using ApartmentManagement.Domain.Entities;
using AutoMapper;

namespace ApartmentManagement.Application.Features.Users.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserListModel>().ReverseMap();
            //CreateMap<User, ListUserQuery>().ReverseMap();
            //CreateMap<UserListModel, ListUserQuery>().ReverseMap();
            CreateMap<UserCreateModel, User>().ReverseMap();
            CreateMap<UserCreateModel, CreateUserCommand>().ReverseMap();
            CreateMap<CreateUserCommand, User>().ReverseMap();
            CreateMap<UserGetByIdModel, User>().ReverseMap();
            CreateMap<UserGetByIdQueries, User>().ReverseMap();
            CreateMap<UserGetByIdQueries, UserGetByIdModel>().ReverseMap();
           
            CreateMap<User, DeleteUserCommand>().ReverseMap();
            CreateMap<User, DeleteUserModel>().ReverseMap();
            CreateMap<DeleteUserCommand, DeleteUserModel>().ReverseMap();
            CreateMap<UpdateUserCommand, User>().ReverseMap();
            CreateMap<UpdateUserCommand, UpdateUserModel>().ReverseMap();
            CreateMap<User, UpdateUserModel>().ReverseMap();


        }
    }
}
