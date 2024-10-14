using DepotBackEnd.MediatR.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DepotBackEnd.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VehicleController(IMediator mediator)
        {
            _mediator = mediator;
        }

    }
}