using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Entity;
using MediatR;
using DepotBackEnd.DTO.Position;

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
        public async Task<PositionContainer?> GetPositionByContainerNumberAsync(string containerNumber)
        {
            return await _context.PositionContainers
        .FirstOrDefaultAsync(pc => pc.ContainerNumber == containerNumber && pc.Status == "active");
        }

        //create position theo container được duyệt
        public async Task<PositionContainer> CreateAsync(PositionContainer positionContainer)
        {
            _context.PositionContainers.Add(positionContainer);
            await _context.SaveChangesAsync();
            return positionContainer;
        }
        //public async Task<PositionContainer?> GetByIdAsync(int id)
        //{
        //    return await _context.PositionContainers.FindAsync(id);
        //}
        //cập nhập trạng thái position khi xuất bãi
        public async Task<PositionContainer> UpdateAsync(PositionContainer positionContainer)
        {
            _context.PositionContainers.Update(positionContainer);
            await _context.SaveChangesAsync();
            return positionContainer;
        }
    }
}
