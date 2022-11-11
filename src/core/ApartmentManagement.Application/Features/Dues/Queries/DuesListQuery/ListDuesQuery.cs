

using ApartmentManagement.Application.Features.Circles.Models;
using ApartmentManagement.Application.Features.Circles.Queries.CircleListQuery;
using ApartmentManagement.Application.Features.Dues.Models;
using ApartmentManagement.Application.Repositories.Abstract;
using AutoMapper;
using MediatR;

namespace ApartmentManagement.Application.Features.Dues.Queries.DuesListQuery
{
    public class ListDuesQuery : IRequest<List<DuesListModel>>
    {

    }

    public class ListDuesQueryHandle : IRequestHandler<ListDuesQuery, List<DuesListModel>>
    {
        private readonly IDuesRepository repository;

        private readonly IMapper mapper;

        public ListDuesQueryHandle(IDuesRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<List<DuesListModel>> Handle(ListDuesQuery request, CancellationToken cancellationToken)
        {
            var userList = repository.GetAll(x => x.DeleteStatus == false);

            var mapping = mapper.Map<List<DuesListModel>>(userList);

            return mapping;
        }
    }
}
