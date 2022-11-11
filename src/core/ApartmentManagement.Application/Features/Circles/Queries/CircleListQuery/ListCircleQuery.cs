

using ApartmentManagement.Application.Features.Circles.Models;
using ApartmentManagement.Application.Features.Users.Models;
using ApartmentManagement.Application.Features.Users.Queries.UserListQuery;
using ApartmentManagement.Application.Repositories.Abstract;
using AutoMapper;
using MediatR;

namespace ApartmentManagement.Application.Features.Circles.Queries.CircleListQuery
{
    public class ListCircleQuery : IRequest<List<CircleListModel>>
    {
       
    }

    public class ListCircleQueryHandle : IRequestHandler<ListCircleQuery, List<CircleListModel>>
    {
        private readonly ICircleRepository repository;

        private readonly IMapper mapper;

        public ListCircleQueryHandle(ICircleRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<List<CircleListModel>> Handle(ListCircleQuery request, CancellationToken cancellationToken)
        {
            var userList = repository.GetAll(x => x.DeleteStatus == false);

            var mapping = mapper.Map<List<CircleListModel>>(userList);

            return mapping;
        }
    }
}
