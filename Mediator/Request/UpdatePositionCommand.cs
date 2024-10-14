using Entity;
using MediatR;

namespace DepotBackEnd.Mediator.Request
{
    public class UpdatePositionCommand : IRequest<PositionContainer>
    {
        public int EirNumber { get; set; }
        public UpdatePositionCommand(int eirNumber)
        {
            EirNumber = eirNumber;
        }
    }
}
