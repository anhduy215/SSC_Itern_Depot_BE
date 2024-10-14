using DepotBackEnd.DTO.Container;
using DepotBackEnd.DTO.Eir;
using DepotBackEnd.Mediator.Request;
using DepotBackEnd.MediatR.Request;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DepotBackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EirController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EirController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<EirDTO>>> GetAllEirs()
        {
            var result = await _mediator.Send(new GetAllEirQuery());
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEir([FromBody] CreateEirDTO eirDTO)
        {
            var eir = await _mediator.Send(new CreateEirCommand(eirDTO));
            return Created(string.Empty, eir);
        }

        [HttpPut("{eirNumber}")]
        public async Task<IActionResult> UpdateEir(int eirNumber, [FromBody] UpdateEirDTO eirDTO)
        {
            var command = new UpdateEirCommand(eirNumber, eirDTO);
            var updatedEir = await _mediator.Send(command);
            return Ok(updatedEir);
        }
    }
}