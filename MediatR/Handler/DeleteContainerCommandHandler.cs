using DepotBackEnd.MediatR.Request;
using MediatR;
using repository;

namespace DepotBackEnd.MediatR.Handler
{
    public class DeleteContainerCommandHandler : IRequestHandler<DeleteContainerCommand, bool>
    {
        private readonly ContainerRepository _containerRepository;

        public DeleteContainerCommandHandler(ContainerRepository containerRepository)
        {
            _containerRepository = containerRepository;
        }

        public async Task<bool> Handle(DeleteContainerCommand request, CancellationToken cancellationToken)
        {
            return await _containerRepository.DeleteContainerAsync(request.ContainerNumber);
        }
    }
}
