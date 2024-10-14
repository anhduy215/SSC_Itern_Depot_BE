using Microsoft.AspNetCore.Mvc;
using MediatR;
using DepotBackEnd.MediatR.Request;
using DepotBackEnd.DTO.Container;

namespace DepotBackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContainerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ContainerController(IMediator mediator)
        {
            _mediator = mediator;
        }
        //get all
        [HttpGet]
        public async Task<ActionResult<List<ContainerDTO>>> GetAllContainers(CancellationToken cancellationToken)
        {
            var containers = await _mediator.Send(new GetAllContainersQuery(), cancellationToken);
            return Ok(containers);
        }

        //create
        [HttpPost]
        public async Task<IActionResult> CreateContainer([FromBody] CreateContainerDTO containerDTO)
        {
            if (containerDTO == null)
            {
                return BadRequest("Container data is required.");
            }
            var container = await _mediator.Send(new CreateContainerCommand(containerDTO));
            return Created(string.Empty, container);
        }

        // Update
        [HttpPut]
        public async Task<IActionResult> UpdateContainer([FromBody] int eirNumber)
        {
            var command = new UpdateContainerCommand(eirNumber);
            var updatedContainer = await _mediator.Send(command);
            return Ok(updatedContainer);
        }

    }
}
