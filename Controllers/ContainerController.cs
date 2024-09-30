using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using service;
using DepotBackEnd.DTO;
using MediatR;
using DepotBackEnd.MediatR;
using DepotBackEnd.MediatR.Queries;

namespace DepotBackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContainerController : ControllerBase
    {
        private readonly ContainerService _containerService;

        public ContainerController(ContainerService containerService)
        {
            _containerService = containerService;
        }

        [HttpGet(Name = "getAllContainer")]
        public async Task<ActionResult<List<ContainerDTO>>> GetAllContainers()
        {
            
            var containers = await _containerService.GetAllContainersAsync();
            return Ok(containers);
        }
    }
}
