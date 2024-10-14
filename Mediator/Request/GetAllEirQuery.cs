using DepotBackEnd.DTO.Eir;
using MediatR;

namespace DepotBackEnd.Mediator.Request
{
    public class GetAllEirQuery : IRequest<List<EirDTO>>
    {
    }
}
