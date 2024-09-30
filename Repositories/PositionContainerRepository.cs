using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Entity;
using System;

namespace DepotBackEnd.Repositories
{
    public class PositionContainerRepository
    {
        private readonly Database _context;

        public PositionContainerRepository(Database context)
        {
            _context = context;
        }

        // Phương thức để lấy tất cả các vị trí container
        public async Task<List<PositionContainer>> GetAllPositionsAsync()
        {
            return await _context.PositionContainers.ToListAsync();
        }

        // Phương thức để lấy vị trí container theo ContainerNumber
        public async Task<PositionContainer> GetPositionByContainerNumberAsync(int containerNumber)
        {
            return await _context.PositionContainers
                .FirstOrDefaultAsync(pc => pc.ContainerNumber == containerNumber);
        }
    }
}
