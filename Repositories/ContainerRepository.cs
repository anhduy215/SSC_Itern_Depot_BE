using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Entity;
using DepotBackEnd.DTO;

namespace repository
{
    public class ContainerRepository
    {
        private readonly Database _context;

        public ContainerRepository(Database context)
        {
            _context = context;
        }

        public async Task<Container> GetContainerByNumberAsync(int containerNumber)
        {
            return await _context.Containers
                .FirstOrDefaultAsync(c => c.ContainerNumber == containerNumber);
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

        public async Task<Container> CreateContainerAsync(CreateContainerDTO containerDTO)
        {
            var container = new Container
            {
                ISO = containerDTO.ISO,
                MaximumWeight = containerDTO.MaximumWeight,
                TareWeight = containerDTO.TareWeight,
                DateOfManufacture = containerDTO.DateOfManufacture,
                SizeID = containerDTO.SizeID,
                ContainerStatusID = containerDTO.ContainerStatusID,
                OwnerID = containerDTO.OwnerID,
                ContainerTypeID = containerDTO.ContainerTypeID,
                VirtualBlockID = containerDTO.VirtualBlockID,
                LocationStatusID = containerDTO.LocationStatusID,
                LineOperatorID = containerDTO.LineOperatorID,
                FullStatusID = containerDTO.FullStatusID
            };

            _context.Containers.Add(container);
            await _context.SaveChangesAsync();
            return container;
        }


        public async Task<Container> UpdateContainerAsync(int ContainerNumber, UpdateContainerDTO containerDTO)
        {
            var existingContainer = await GetContainerByNumberAsync(ContainerNumber);

            if (existingContainer == null)
            {
                return null;
            }
            if (containerDTO.MaximumWeight.HasValue)
                existingContainer.MaximumWeight = containerDTO.MaximumWeight.Value;

            if (containerDTO.TareWeight.HasValue)
                existingContainer.TareWeight = containerDTO.TareWeight.Value;

            if (containerDTO.DateOfManufacture.HasValue)
                existingContainer.DateOfManufacture = containerDTO.DateOfManufacture.Value;

            if (containerDTO.SizeID.HasValue)
                existingContainer.SizeID = containerDTO.SizeID.Value;

            if (containerDTO.ContainerStatusID.HasValue)
                existingContainer.ContainerStatusID = containerDTO.ContainerStatusID.Value;

            if (containerDTO.OwnerID.HasValue)
                existingContainer.OwnerID = containerDTO.OwnerID.Value;

            if (containerDTO.ContainerTypeID.HasValue)
                existingContainer.ContainerTypeID = containerDTO.ContainerTypeID.Value;

            existingContainer.VirtualBlockID = containerDTO.VirtualBlockID;

            if (containerDTO.LocationStatusID.HasValue)
                existingContainer.LocationStatusID = containerDTO.LocationStatusID.Value;

            if (containerDTO.LineOperatorID.HasValue)
                existingContainer.LineOperatorID = containerDTO.LineOperatorID.Value;

            if (containerDTO.FullStatusID.HasValue)
                existingContainer.FullStatusID = containerDTO.FullStatusID.Value;

            _context.Containers.Update(existingContainer);

            await _context.SaveChangesAsync();
            return existingContainer;
        }
        public async Task<bool> DeleteContainerAsync(int containerNumber)
        {
            var existingContainer = await GetContainerByNumberAsync(containerNumber);

            if (existingContainer == null)
            {
                return false;
            }

            _context.Containers.Remove(existingContainer);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}