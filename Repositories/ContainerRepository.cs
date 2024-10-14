using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Entity;
using DepotBackEnd.Service;
using DepotBackEnd.DTO.Container;

namespace DepotBackEnd.Repositories
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
                .Include(c => c.Owner)
                .Include(c => c.LineOperator)
                .Include(c => c.LocationStatus)
                .Include(c => c.ContainerSize)
                .Include(c => c.ContainerType)
                .ToListAsync();
        }
        //lấy cont theo số cont
        public async Task<Container?> GetContainerByNumberAsync(string containerNumber)
        {
            return await _context.Containers
                .FirstOrDefaultAsync(c => c.ContainerNumber == containerNumber);
        }
        //create
        public async Task<Container> CreateContainerAsync(Container container, CancellationToken cancellationToken)
        {
            _context.Containers.Add(container);
            await _context.SaveChangesAsync(cancellationToken);
            return container;
        }

        //update
        public async Task<Container?> UpdateContainerAsync(Container Container)
        {
            _context.Containers.Update(Container);
            await _context.SaveChangesAsync();
            return Container;
        }

    }
}