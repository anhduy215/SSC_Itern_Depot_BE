using DepotBackEnd.Mediator.Request;
using DepotBackEnd.Repositories;
using Entity;
using MediatR;

namespace DepotBackEnd.Mediator.Handler
{
    public class UpdatePositionCommandHandler : IRequestHandler<UpdatePositionCommand, PositionContainer>
    {
        private readonly PositionContainerRepository _repository;
        private readonly EirRepository _eirRepository;

        public UpdatePositionCommandHandler(PositionContainerRepository repository, EirRepository eirRepository)
        {
            _repository = repository;
            _eirRepository = eirRepository;
        }

        public async Task<PositionContainer> Handle(UpdatePositionCommand request, CancellationToken cancellationToken)
        {
            var eir = await _eirRepository.GetEirByIdAsync(request.EirNumber);
            if (eir == null)
            {
                throw new ArgumentException("EIR not found for the given container number.");
            }

            var positionContainer = await _repository.GetPositionByContainerNumberAsync(eir.ContainerNumber);
            if (positionContainer == null)
            {
                throw new ArgumentException("Position not found for the given container number.");
            }

            // Kiểm tra nếu Approvements không phải là "Approve" hoặc Type không phải là "Export"
            if (eir.Approvements != "Approve" || eir.EirType != "Export")
            {
                throw new ArgumentException("Container has not been approved to Export.");
            }

            positionContainer.Status = "inactive";

            await _repository.UpdateAsync(positionContainer);

            return positionContainer;
        }
    }

}
