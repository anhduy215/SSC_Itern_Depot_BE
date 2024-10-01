using MediatR;

namespace DepotBackEnd.MediatR.Request
{
    public class DeleteContainerCommand : IRequest<bool>
    {
        public int ContainerNumber { get; }

        public DeleteContainerCommand(int containerNumber)
        {
            ContainerNumber = containerNumber;
        }
    }
}
