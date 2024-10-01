using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using DepotBackEnd.DTO;
using MediatR;
using DepotBackEnd.MediatR.Request;

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
        [HttpGet(Name = "getAllContainer")]
        public async Task<ActionResult<List<ContainerDTO>>> GetAllContainers()
        {
            
            var containers = await _mediator.Send(new GetAllContainersQuery());
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
            return Created(string.Empty, container); // Trả về mã trạng thái 201
        }

        //update
        [HttpPut("{containerNumber}")]
        public async Task<IActionResult> UpdateContainer(int containerNumber, [FromBody] UpdateContainerDTO containerDTO)
        {
            if (containerDTO == null)
            {
                return BadRequest("Container data is required.");
            }

            var command = new UpdateContainerCommand(containerNumber, containerDTO);
            var updatedContainer = await _mediator.Send(command);

            if (updatedContainer == null)
            {
                return NotFound($"Container with number {containerNumber} not found.");
            }

            return Ok(updatedContainer);
        }

        //delete
        [HttpDelete("{containerNumber}")]
        public async Task<IActionResult> DeleteContainer(int containerNumber)
        {
            var result = await _mediator.Send(new DeleteContainerCommand(containerNumber));

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
