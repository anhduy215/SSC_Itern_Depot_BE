using DepotBackEnd.Mediator.Request;
using DepotBackEnd.Repositories;
using Entity;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace DepotBackEnd.Mediator.Handler
{
    public class LoginHandler : IRequestHandler<LoginCommand, UserAccount>
    {
        private readonly UserRepository _userRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public LoginHandler(UserRepository userRepository, IHttpContextAccessor httpContextAccessor)
        {
            _userRepository = userRepository;
            _httpContextAccessor = httpContextAccessor;

        }

        public async Task<UserAccount> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            // Tìm người dùng từ database qua UserRepository
            var user = await _userRepository.GetUserByCredentialsAsync(request.LoginDTO);
            if (user == null)
            {
                throw new UnauthorizedAccessException("Invalid username or password.");
            }

            // Lưu thông tin người dùng vào session
            var session = _httpContextAccessor.HttpContext?.Session;
            if (session != null)
            {
                session.SetInt32("UserID", user.UserID); // Lưu UserID vào session
                session.SetString("UserName", user.UserName); // Lưu UserName vào session
            }

            return user;
        }
    }
}
