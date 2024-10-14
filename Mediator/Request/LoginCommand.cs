using DepotBackEnd.DTO.Login;
using Entity;
using MediatR;

namespace DepotBackEnd.Mediator.Request
{
    public class LoginCommand : IRequest<UserAccount>
    {
        public LoginDTO LoginDTO { get; }

        public LoginCommand(LoginDTO loginDTO)
        {
            LoginDTO = loginDTO;
        }
    }
}