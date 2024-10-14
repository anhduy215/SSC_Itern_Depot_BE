using DepotBackEnd.MediatR.Request;
using Entity;
using MediatR;
using DepotBackEnd.Repositories;
using DepotBackEnd.DTO.Container;
using DepotBackEnd.Service;

namespace DepotBackEnd.MediatR.Handler
{
    public class CreateContainerCommandHandler : IRequestHandler<CreateContainerCommand, Container>
    {
        private readonly ContainerRepository _containerRepository;

        public CreateContainerCommandHandler(ContainerRepository containerRepository)
        {
            _containerRepository = containerRepository;
        }

        public async Task<Container> Handle(CreateContainerCommand request, CancellationToken cancellationToken)
        {
            var containerDTO = request.Container;
            // Kiểm tra check digit của số container
            var checkDigitService = new CheckDigitService();
            bool IsValidContainerNumber = checkDigitService.IsValidContainerNumber(containerDTO.ContainerNumber);

            if (!IsValidContainerNumber)
            {
                throw new ArgumentException("Container number is invalid due to incorrect check digit.");
            }

            var container = new Container
            {
                ContainerNumber = containerDTO.ContainerNumber,
                ISO = containerDTO.ISO,
                MaximumWeight = containerDTO.MaximumWeight,
                TareWeight = containerDTO.TareWeight,
                DateOfManufacture = containerDTO.DateOfManufacture,
                SizeID = containerDTO.SizeID,
                ContainerStatus = containerDTO.ContainerStatus,
                OwnerID = containerDTO.OwnerID,
                ContainerTypeID = containerDTO.ContainerTypeID,
                LineOperatorID = containerDTO.LineOperatorID,
                FullStatusID = containerDTO.FullStatusID
            };

            return await _containerRepository.CreateContainerAsync(container, cancellationToken);
        }
    }
}