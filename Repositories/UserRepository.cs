using DepotBackEnd.DTO.Login;
using Entity;
using Microsoft.EntityFrameworkCore;

namespace DepotBackEnd.Repositories
{
    public class UserRepository
    {
        private readonly Database _context;

        public UserRepository(Database context)
        {
            _context = context;
        }

        public async Task<UserAccount?> GetUserByCredentialsAsync(LoginDTO loginDTO)
        {
            // Tìm kiếm người dùng trong cơ sở dữ liệu dựa trên UserName và Password
            return await _context.UserAccounts
                .FirstOrDefaultAsync(u => u.UserName == loginDTO.UserName && u.UserPassword == loginDTO.Password);
        }
    }
}
