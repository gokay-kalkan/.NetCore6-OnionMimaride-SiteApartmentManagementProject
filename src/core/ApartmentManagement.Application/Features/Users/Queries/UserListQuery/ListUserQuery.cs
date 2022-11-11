

using ApartmentManagement.Application.Features.Users.Models;
using ApartmentManagement.Application.Repositories.Abstract;
using ApartmentManagement.Domain.Entities;
using AutoMapper;
using MediatR;
using System.Collections.Generic;

namespace ApartmentManagement.Application.Features.Users.Queries.UserListQuery
{
    public class ListUserQuery:IRequest<List<UserListModel>>
    {
       

    }

    public class ListUserQueryHandle : IRequestHandler<ListUserQuery, List<UserListModel>>
    {
        private readonly IUserRepository repository;

        private readonly IMapper mapper;

        public ListUserQueryHandle(IUserRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<List<UserListModel>> Handle(ListUserQuery request, CancellationToken cancellationToken)
        {
            var userList = repository.GetAll(x=>x.DeleteStatus==false);

          var mapping = mapper.Map<List<UserListModel>>(userList);

            return mapping;
        }
    }
}
