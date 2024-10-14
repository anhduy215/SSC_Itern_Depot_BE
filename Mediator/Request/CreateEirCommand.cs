using DepotBackEnd.DTO.Eir;
using DepotBackEnd.Entities;
using MediatR;

namespace DepotBackEnd.Mediator.Request
{
    public class CreateEirCommand : IRequest<Eir>
    {
        public CreateEirDTO EirDTO { get; set; }

        public CreateEirCommand(CreateEirDTO eirDTO)
        {
            EirDTO = eirDTO;
        }
    }
}
