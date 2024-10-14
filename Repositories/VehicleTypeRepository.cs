using Entity;

namespace DepotBackEnd.Repositories
{
    public class VehicleTypeRepository
    {
        private readonly Database _context;

        public VehicleTypeRepository(Database context)
        {
            _context = context;
        }

        public async Task<VehicleType?> GetVehicleTypeByIdAsync(int vehicleTypeId)
        {
            return await _context.VehicleTypes.FindAsync(vehicleTypeId);
        }
    }
}
