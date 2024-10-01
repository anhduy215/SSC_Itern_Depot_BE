using DepotBackEnd.MediatR.Request;
using Entity;
using MediatR;
using repository;

namespace DepotBackEnd.MediatR.Handler
{
    public class UpdateContainerCommandHandler : IRequestHandler<UpdateContainerCommand, Container>
    {
        private readonly ContainerRepository _containerRepository;

        public UpdateContainerCommandHandler(ContainerRepository containerRepository)
        {
            _containerRepository = containerRepository;
        }

        public async Task<Container> Handle(UpdateContainerCommand request, CancellationToken cancellationToken)
        {
            var containerDTO = request.Container;

            return await _containerRepository.UpdateContainerAsync(request.ContainerNumber, containerDTO);
        }
    }
}