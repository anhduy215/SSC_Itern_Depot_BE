using DepotBackEnd.DTO;
using Entity;
using MediatR;

namespace DepotBackEnd.MediatR.Request
{
    public class CreateContainerCommand : IRequest<Container>
    {
        public CreateContainerDTO Container { get; set; }

        public CreateContainerCommand(CreateContainerDTO container)
        {
            Container = container;
        }
    }
}
