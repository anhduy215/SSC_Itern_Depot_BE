using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using MediatR;
using DepotBackEnd.MediatR.Request;
using DepotBackEnd.DTO.Position;
using DepotBackEnd.Mediator.Request;

namespace DepotBackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PositionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PositionController(IMediator mediator)
        {
            _mediator = mediator;
        }
        //create
        [HttpPost]
        public async Task<IActionResult> CreatePosition([FromBody] int eirNumber)
        {
            var position = await _mediator.Send(new CreatePositionCommand(eirNumber));
            return Created(string.Empty, position); // Trả về mã trạng thái 201
        }
        [HttpPut]
        public async Task<IActionResult> UpdatePosition([FromBody] int eirNumber)
        {
            var position = await _mediator.Send(new UpdatePositionCommand(eirNumber));
            return Ok(position); // Trả về mã trạng thái 200
        }

    }
}
