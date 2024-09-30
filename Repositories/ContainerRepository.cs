using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Entity;

namespace repository
{
    public class ContainerRepository
    {
        private readonly Database _context;

        public ContainerRepository(Database context)
        {
            _context = context;
        }

        public async Task<List<Container>> GetAllContainersAsync()
        {
            return await _context.Containers
                .Include(c => c.ContainerOwner)
                .Include(c => c.LineOperator)
                .Include(c => c.LocationStatus)
                .Include(c => c.ContainerSize)
                .ToListAsync();
        }
    }
}