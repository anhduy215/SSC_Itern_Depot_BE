using Entity;
using Microsoft.EntityFrameworkCore;

namespace DepotBackEnd.Repositories
{
    public class VehicleRepository
    {
        private readonly Database _context;

        public VehicleRepository(Database context)
        {
            _context = context;
        }
      
        public async Task<Vehicle?> GetVehicleByLicensePlateAsync(string licensePlate)
        {
            return await _context.Vehicles.FirstOrDefaultAsync(v => v.LicensePlate == licensePlate);
        }
    }
}
