

using ApartmentManagement.Application.Features.Circles.Models;
using ApartmentManagement.Application.Features.Users.Models;
using ApartmentManagement.Application.Features.Users.Queries.GetByIdUser;
using ApartmentManagement.Application.Repositories.Abstract;
using ApartmentManagement.Domain.Entities;
using AutoMapper;
using MediatR;

namespace ApartmentManagement.Application.Features.Circles.Queries.GetByIdCircle
{
    public class GetByIdCircleQuery:IRequest<CircleGetByIdModel>
    {
        public int CircleId { get; set; }

        public string CircleNo { get; set; }

        public int UserId { get; set; }

        public string TenantOwner { get; set; }

        public int LivingPeopleCount { get; set; }
    }

    public class  GetByIdCircleQueryHandle : IRequestHandler<GetByIdCircleQuery, CircleGetByIdModel>
    {
        private readonly ICircleRepository repository;

        private readonly IMapper mapper;

        public GetByIdCircleQueryHandle(ICircleRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<CircleGetByIdModel> Handle(GetByIdCircleQuery request, CancellationToken cancellationToken)
        {
            Circle circle = repository.GetOne(request.CircleId);

            //_brandBusinessRules.BrandShouldExistWhenRequested(brand);

            CircleGetByIdModel circleModel = mapper.Map<CircleGetByIdModel>(circle);
            return circleModel;
        }
    }

}
