using DepotBackEnd.Entities;
using DepotBackEnd.Mediator.Request;
using DepotBackEnd.Repositories;
using MediatR;

namespace DepotBackEnd.Mediator.Handler
{
    public class CreateEirCommandHandler : IRequestHandler<CreateEirCommand, Eir>
    {
        private readonly EirRepository _eirRepository;
        private readonly ContainerRepository _containerRepository;

        public CreateEirCommandHandler(EirRepository eirRepository, ContainerRepository containerRepository)
        {
            _eirRepository = eirRepository;
            _containerRepository = containerRepository;
        }

        public async Task<Eir> Handle(CreateEirCommand request, CancellationToken cancellationToken)
        {
            var eirDTO = request.EirDTO;
            var container = await _containerRepository.GetContainerByNumberAsync(eirDTO.ContainerNumber);

            // Kiểm tra nếu container đã có phiếu EIR chờ duyệt thì không được tạo phiếu eir cho container đó nữa
            int pendingEirCount = await _eirRepository.CountPendingEirsByContainerNumberAsync(eirDTO.ContainerNumber);
            if (pendingEirCount >= 1)
            {
                throw new InvalidOperationException($"Cannot create EIR, container {eirDTO.ContainerNumber} already has a pending EIR.");
            }

            // Kiểm tra EirType phải là "Export" hoặc "Import"
            if (eirDTO.EirType != "Export" && eirDTO.EirType != "Import")
            {
                throw new ArgumentException("EirType must be either 'Export' or 'Import'.");
            }

            // Nếu EirType là "Export", Deadline không được null
            if (eirDTO.EirType == "Export" && eirDTO.Deadline == null)
            {
                throw new ArgumentException("Deadline is required when EirType is 'Export'.");
            }

            // check vị trí của container trước khi khai phiếu eir

            if (eirDTO.EirType == "Export" && container?.LocationStatusID != 1)
            {
                throw new ArgumentException("Eir Export, LocationStatusID must be 1.");
            }
            else if (eirDTO.EirType == "Import" && container?.LocationStatusID != null)
            {
                throw new ArgumentException("Eir Import, LocationStatusID must be null.");
            }

            // Kiểm tra giới hạn số lượng container loại 20 (SizeID = 1)
            if (container?.SizeID == 1)
            {
                int countSize20 = await _eirRepository.CountPendingEirsByContainerSizeAndVehicleAsync(eirDTO.LicensePlate, 1);
                if (countSize20 >= 2)
                {
                    throw new InvalidOperationException("Cannot create EIR, there are already 2 size 20 containers pending approval on this vehicle.");
                }
            }

            // Kiểm tra giới hạn số lượng container loại 40 hoặc 45 (SizeID = 2 hoặc 3)
            if (container?.SizeID == 2 || container?.SizeID == 3)
            {
                int countSize40_45 = await _eirRepository.CountPendingEirsByContainerSizeAndVehicleAsync(eirDTO.LicensePlate, container.SizeID);
                if (countSize40_45 >= 1)
                {
                    throw new InvalidOperationException("Cannot create EIR, there is already 1 size 40 or 45 container pending approval on this vehicle.");
                }
            }

            // Tạo đối tượng Eir từ DTO
            var eir = new Eir
            {
                CustomerName = eirDTO.CustomerName,
                TaxCode = eirDTO.TaxCode,
                Deadline = eirDTO.Deadline,
                CreateDate = DateTime.Now, // Gán ngày tạo là hiện tại
                EirType = eirDTO.EirType,
                LineOperatorID = eirDTO.LineOperatorID,
                ContainerNumber = eirDTO.ContainerNumber,
                LicensePlate = eirDTO.LicensePlate,
            };
            return await _eirRepository.CreateEirAsync(eir, cancellationToken);
        }
    }
}