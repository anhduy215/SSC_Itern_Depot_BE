using MediatR;
using DepotBackEnd.MediatR.Request;
using DepotBackEnd.Repositories;
using DepotBackEnd.DTO.Container;

namespace DepotBackEnd.MediatR.Handler
{
    public class GetAllContainersQueryHandler : IRequestHandler<GetAllContainersQuery, List<ContainerDTO>>
    {
        private readonly ContainerRepository _containerRepository;
        private readonly PositionContainerRepository _positionRepository;


        public GetAllContainersQueryHandler(ContainerRepository containerRepository, PositionContainerRepository positionRepository)
        {
            _containerRepository = containerRepository;
            _positionRepository = positionRepository;
        }
        public async Task<List<ContainerDTO>> Handle(GetAllContainersQuery request, CancellationToken cancellationToken)
        {
            var containers = await _containerRepository.GetAllContainersAsync();
            var result = new List<ContainerDTO>();

            foreach (var c in containers)
            {
                var positionValue = string.Empty;
                // Luôn lấy thông tin từ PositionContainer
                var positionContainer = await _positionRepository.GetPositionByContainerNumberAsync(c.ContainerNumber);
                if (positionContainer != null && positionContainer.Status == "active")
                {
                    positionValue = $"Block: {positionContainer.BlockID}, B: {positionContainer.Bay}, R: {positionContainer.RowNumber}, T: {positionContainer.TierNumber}";
                }

                result.Add(new ContainerDTO
                {
                    ContainerNumber = c.ContainerNumber,
                    ISO = c.ISO ?? string.Empty,
                    MaximumWeight = c.MaximumWeight,
                    TareWeight = c.TareWeight,
                    DateOfManufacture = c.DateOfManufacture ?? default,
                    ContainerStatus = c.ContainerStatus,
                    Size = c.ContainerSize?.SizeContainer ?? 0,
                    OwnerName = c.Owner?.OwnerName ?? string.Empty,
                    ContainerType = c.ContainerType?.TypeName ?? string.Empty,
                    LocationStatus = c.LocationStatus?.Status ?? string.Empty,
                    Position = string.IsNullOrEmpty(positionValue) ? null : positionValue
                });
            }

            return result;
        }
    }
}