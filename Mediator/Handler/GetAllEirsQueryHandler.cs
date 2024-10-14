using DepotBackEnd.DTO.Eir;
using DepotBackEnd.Mediator.Request;
using DepotBackEnd.Repositories;
using Entity;
using MediatR;

namespace DepotBackEnd.Mediator.Handler
{
    public class GetAllEirsQueryHandler : IRequestHandler<GetAllEirQuery, List<EirDTO>>
    {
        private readonly EirRepository _eirRepository;

        public GetAllEirsQueryHandler(EirRepository eirRepository, VehicleTypeRepository vehicleTypeRepository, LineOperatorRepository lineOperRepository, VehicleRepository vehicleRepository)
        {
            _eirRepository = eirRepository;
        }

        public async Task<List<EirDTO>> Handle(GetAllEirQuery request, CancellationToken cancellationToken)
        {
            var eirs = await _eirRepository.GetAllEirsAsync();
            var result = new List<EirDTO>();

            foreach (var eir in eirs)
            {
                result.Add(new EirDTO
                {
                    EirNumber = eir.EirNumber,
                    CustomerName = eir.CustomerName,
                    TaxCode = eir.TaxCode,
                    ContainerNumber = eir.ContainerNumber,
                    LineOperator = eir.LineOperator?.LineOperatorName ?? string.Empty,
                    VehicleTypeName = eir.Vehicle?.VehicleType?.VehicleTypeName ?? string.Empty,
                    LicensePlate = eir.LicensePlate,
                    Deadline = eir.Deadline,
                    EirType = eir.EirType,
                    Approvements = eir.Approvements,
                    UserID = eir.UserID,
                });
            }

            return result;
        }
    }
}