using DepotBackEnd.DTO;
using Entity;
using MediatR;

namespace DepotBackEnd.MediatR.Request
{
    public class UpdateContainerCommand : IRequest<Container>
    {
        public int ContainerNumber { get; set; }
        public UpdateContainerDTO Container { get; set; }

        public UpdateContainerCommand(int containerNumber, UpdateContainerDTO container)
        {
            ContainerNumber = containerNumber;
            Container = container;
        }
    }
}
