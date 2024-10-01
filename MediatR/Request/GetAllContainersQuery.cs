using DepotBackEnd.DTO;
using MediatR;
using System.Collections.Generic;

namespace DepotBackEnd.MediatR.Request
{
    public class GetAllContainersQuery : IRequest<List<ContainerDTO>>
    {
    }
}
