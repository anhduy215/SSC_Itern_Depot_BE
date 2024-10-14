using DepotBackEnd.DTO.Container;
using Entity;
using MediatR;

namespace DepotBackEnd.MediatR.Request
{
    public class CreateContainerCommand : IRequest<Container>
    {
        public CreateContainerDTO Container { get; }

        public CreateContainerCommand(CreateContainerDTO createContainer)
        {
            Container = createContainer;
        }
    }
}
