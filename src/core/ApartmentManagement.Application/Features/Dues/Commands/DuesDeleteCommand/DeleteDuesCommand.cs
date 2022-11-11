

using ApartmentManagement.Application.Features.Circles.Commands.CircleDeleteCommand;
using ApartmentManagement.Application.Features.Circles.Models;
using ApartmentManagement.Application.Features.Dues.Models;
using ApartmentManagement.Application.Repositories.Abstract;
using AutoMapper;
using MediatR;

namespace ApartmentManagement.Application.Features.Dues.Commands.DuesDeleteCommand
{
    public class DeleteDuesCommand:IRequest<DuesDeleteModel>
    {
        public int DuesId { get; set; }
    }

    public class DeleteDuesCommandHandle : IRequestHandler<DeleteDuesCommand, DuesDeleteModel>
    {
        private readonly IDuesRepository repository;

        private readonly IMapper mapper;

        public DeleteDuesCommandHandle(IDuesRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<DuesDeleteModel> Handle(DeleteDuesCommand request, CancellationToken cancellationToken)
        {
            var dues = repository.GetOne(request.DuesId);
            dues.DeleteStatus = true;
            repository.Update(dues);

            var dto = mapper.Map<DuesDeleteModel>(dues);

            return dto;
        }
    }

}
