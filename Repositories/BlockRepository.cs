using Entity;
using Microsoft.EntityFrameworkCore;

namespace DepotBackEnd.Repositories
{
    public class BlockRepository
    {
        private readonly Database _context;

        public BlockRepository(Database context)
        {
            _context = context;
        }
        // Phương thức lấy tất cả các block
        public async Task<List<Block>> GetAllBlocksAsync()
        {
            return await _context.Blocks.ToListAsync();
        }
    }
}
