
using ApartmentManagement.Application.Features.Circles.Commands.CircleCreateCommand;
using ApartmentManagement.Application.Features.Circles.Models;
using ApartmentManagement.Application.Features.Dues.Models;
using ApartmentManagement.Application.Repositories.Abstract;
using ApartmentManagement.Domain.Entities;
using AutoMapper;
using MediatR;

namespace ApartmentManagement.Application.Features.Dues.Commands.DuesCreateCommand
{
    public class CreateDuesCommand : IRequest<DuesCreateModel>
    {
        public int DuesId { get; set; }

        public string DuesType { get; set; }

        public int CircleId { get; set; }

        public int UserId { get; set; }

        public double DuesPrice { get; set; }

        public DateTime PaymentDate { get; set; }

        public DateTime PaymentDeadline { get; set; }

      
    }


    public class CreateDuesCommandHandle : IRequestHandler<CreateDuesCommand, DuesCreateModel>
    {
        private readonly IDuesRepository repository;

        private readonly IMapper mapper;

        public CreateDuesCommandHandle(IDuesRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<DuesCreateModel> Handle(CreateDuesCommand request, CancellationToken cancellationToken)
        {

            var dues = mapper.Map<Domain.Entities.Dues>(request);
            dues.DeleteStatus = false;
            dues.PaidStatus = false;
           

            Domain.Entities.Dues createDues = await repository.AddAsync(dues);

            DuesCreateModel createdDuesModel = mapper.Map<DuesCreateModel>(createDues);
            return createdDuesModel;
        }
    }
}
