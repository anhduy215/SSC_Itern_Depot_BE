using DepotBackEnd.MediatR.Request;
using Entity;
using MediatR;
using DepotBackEnd.Repositories;

namespace DepotBackEnd.MediatR.Handler
{
    public class UpdateContainerCommandHandler : IRequestHandler<UpdateContainerCommand, Container>
    {
        private readonly ContainerRepository _containerRepository;
        private readonly EirRepository _eirRepository;

        public UpdateContainerCommandHandler(ContainerRepository containerRepository, EirRepository eirRepository)
        {
            _containerRepository = containerRepository;
            _eirRepository = eirRepository;
        }

        public async Task<Container?> Handle(UpdateContainerCommand request, CancellationToken cancellationToken)
        {
            // Lấy thông tin EIR của container
            var eir = await _eirRepository.GetEirByIdAsync(request.EirNumber);
            if (eir == null)
            {
                throw new ArgumentException("EIR not found");
            }

            // Tìm container dựa trên ContainerNumber
            var existingContainer = await _containerRepository.GetContainerByNumberAsync(eir.ContainerNumber);
            if (existingContainer == null)
            {
                throw new ArgumentException("Container not found.");
            }

            // Cập nhật LocationStatusID dựa trên trạng thái duyệt
            if (eir.Approvements == "Approve" && eir.EirType == "Import")
            {
                existingContainer.LocationStatusID = 1; // duyệt import
            }
            else if (eir.Approvements == "Approve" && eir.EirType == "Export")
            {
                existingContainer.LocationStatusID = 3; // duyệt Export
            }

            // Lưu thay đổi
            return await _containerRepository.UpdateContainerAsync(existingContainer);
        }
    }

}