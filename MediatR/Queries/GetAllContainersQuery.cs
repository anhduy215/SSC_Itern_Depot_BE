using DepotBackEnd.DTO;
using MediatR;
using System.Collections.Generic;

namespace DepotBackEnd.MediatR.Queries
{
    public class GetAllContainersQuery : IRequest<List<ContainerDTO>>
    {
    }
}
