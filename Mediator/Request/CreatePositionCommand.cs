using DepotBackEnd.DTO.Position;
using Entity;
using MediatR;

namespace DepotBackEnd.MediatR.Request
{
    public class CreatePositionCommand : IRequest<PositionContainer>
    {
        public int EirNumber { get; set; }

        public CreatePositionCommand(int eirNumber)
        {
            EirNumber = eirNumber;
        }
    }
}
