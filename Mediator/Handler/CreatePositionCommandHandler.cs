using Entity;
using MediatR;
using DepotBackEnd.MediatR.Request;
using DepotBackEnd.Repositories;

namespace DepotBackEnd.MediatR.Handler
{
    public class CreatePositionCommandHandler : IRequestHandler<CreatePositionCommand, PositionContainer>
    {
        private readonly PositionContainerRepository _repository;
        private readonly EirRepository _eirRepository;
        private readonly BlockRepository _blockRepository;

        public CreatePositionCommandHandler(PositionContainerRepository repository, EirRepository eirRepository, BlockRepository blockRepository)
        {
            _repository = repository;
            _eirRepository = eirRepository;
            _blockRepository = blockRepository;
        }

        public async Task<PositionContainer> Handle(CreatePositionCommand request, CancellationToken cancellationToken)
        {
            var eir = await _eirRepository.GetEirByIdAsync(request.EirNumber);
            if (eir == null)
            {
                throw new ArgumentException("EIR not found for the given container number.");
            }

            // Kiểm tra nếu Approvements không phải là "Approve"
            if (eir.Approvements != "Approve" || eir.EirType != "Import")
            {
                throw new ArgumentException("Container has not been approved to import depot.");
            }

            // Kiểm tra xem container đã có vị trí nào đang active hay chưa
            var existingPositions = await _repository.GetAllPositionsAsync();
            var isContainerActive = existingPositions.Any(pc =>
                pc.ContainerNumber == eir.ContainerNumber &&
                pc.Status == "active"
            );

            if (isContainerActive)
            {
                throw new InvalidOperationException("Container already has an active position and cannot be assigned a new one.");
            }

            // Lấy tất cả các block
            var blocks = await _blockRepository.GetAllBlocksAsync();

            // Tìm vị trí trống trong từng block
            foreach (var block in blocks)
            {
                for (int bay = 1; bay <= block.BayRange; bay++)
                {
                    for (int row = 1; row <= block.RowRange; row++)
                    {
                        for (int tier = 1; tier <= block.TierRange; tier++)
                        {
                            // Kiểm tra vị trí đang check đã trùng với các vị trí đang hiện có không
                            var existingPosition = await _repository.GetAllPositionsAsync();
                            var isPositionOccupied = existingPosition.Any(pc =>
                                pc.BlockID == block.BlockID &&
                                pc.Bay == bay &&
                                pc.RowNumber == row &&
                                pc.TierNumber == tier &&
                                pc.Status == "active"
                            );

                            // Nếu vị trí còn trống, gán vị trí cho container
                            if (!isPositionOccupied)
                            {
                                var positionContainer = new PositionContainer
                                {
                                    ContainerNumber = eir.ContainerNumber,
                                    BlockID = block.BlockID,
                                    Bay = bay,
                                    RowNumber = row,
                                    TierNumber = tier,
                                    Status = "active"
                                };

                                // Lưu vị trí
                                return await _repository.CreateAsync(positionContainer);
                            }
                        }
                    }
                }
            }

            throw new InvalidOperationException("No available positions found for the container.");
        }
    }
}