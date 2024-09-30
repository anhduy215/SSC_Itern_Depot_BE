using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DepotBackEnd.DTO;
using DepotBackEnd.MediatR.Queries;
using MediatR;
using repository;

namespace service
{
    public class ContainerService
    {
        private readonly IMediator _mediator;

        public ContainerService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<List<ContainerDTO>> GetAllContainersAsync()
        {
            return await _mediator.Send(new GetAllContainersQuery());
        }
    }
}
