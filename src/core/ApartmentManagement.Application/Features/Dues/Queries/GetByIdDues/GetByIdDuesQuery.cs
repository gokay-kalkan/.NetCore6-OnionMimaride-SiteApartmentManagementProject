

using ApartmentManagement.Application.Features.Circles.Models;
using ApartmentManagement.Application.Features.Circles.Queries.GetByIdCircle;
using ApartmentManagement.Application.Features.Dues.Models;
using ApartmentManagement.Application.Repositories.Abstract;
using ApartmentManagement.Domain.Entities;
using AutoMapper;
using MediatR;

namespace ApartmentManagement.Application.Features.Dues.Queries.GetByIdDues
{
    public class GetByIdDuesQuery : IRequest<DuesGetByIdModel>
    {
        public int DuesId { get; set; }

        public string? DuesType { get; set; }

        public int? CircleId { get; set; }

        public int? UserId { get; set; }

        public double? DuesPrice { get; set; }

        public DateTime? PaymentDate { get; set; }

        public bool PaidStatus { get; set; }

        public DateTime PaymentDeadline { get; set; }

     
    }

    public class GetByIdDuesQueryHandle : IRequestHandler<GetByIdDuesQuery, DuesGetByIdModel>
    {
        private readonly IDuesRepository repository;

        private readonly IMapper mapper;

        public GetByIdDuesQueryHandle(IDuesRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<DuesGetByIdModel> Handle(GetByIdDuesQuery request, CancellationToken cancellationToken)
        {
            var dues = repository.GetOne(request.DuesId);

            //_brandBusinessRules.BrandShouldExistWhenRequested(brand);
            
            DuesGetByIdModel duesModel = mapper.Map<DuesGetByIdModel>(dues);
            return duesModel;
        }
    }
}
