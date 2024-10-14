using DepotBackEnd.DTO.Container;
using Entity;
using MediatR;

namespace DepotBackEnd.MediatR.Request
{
    public class UpdateContainerCommand : IRequest<Container>
    {
        public int EirNumber { get; set; }
        public UpdateContainerCommand(int eirNumber)
        {
            EirNumber = eirNumber;
        }
    }
}
