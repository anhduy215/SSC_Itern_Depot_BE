using DepotBackEnd.DTO.Login;
using DepotBackEnd.Mediator.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DepotBackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LoginController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            // Gửi command tới Mediator để xử lý đăng nhập
            var token = await _mediator.Send(new LoginCommand(loginDTO));
            return Ok(new { Token = token });
        }
    }
}