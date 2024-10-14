using DepotBackEnd.DTO.Eir;
using DepotBackEnd.Entities;
using MediatR;

namespace DepotBackEnd.Mediator.Request
{
    public class UpdateEirCommand : IRequest<Eir>
    {
        public int EirNumber { get; set; }
        public UpdateEirDTO? EirDTO { get; set; }
        public UpdateEirCommand(int eirNumber, UpdateEirDTO? eirDTO)
        {
            EirNumber = eirNumber;
            EirDTO = eirDTO;
        }
    }
}
