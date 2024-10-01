using DepotBackEnd.MediatR.Request;
using Entity;
using MediatR;
using repository;

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
            return await _containerRepository.CreateContainerAsync(request.Container);
        }
    }
}