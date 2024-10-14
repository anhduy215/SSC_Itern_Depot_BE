using DepotBackEnd.Entities;
using Microsoft.EntityFrameworkCore;

namespace DepotBackEnd.Repositories
{
    public class EirRepository
    {
        private readonly Database _context;

        public EirRepository(Database context)
        {
            _context = context;
        }
        public async Task<List<Eir>> GetAllEirsAsync()
        {
            return await _context.Eir
                .Include(e => e.LineOperator)
                .Include(e => e.Vehicle)
                    .ThenInclude(v => v.VehicleType)
                .Include(e => e.Container)
                .ToListAsync();
        }
        //đếm số eir theo size và phương tiện chở(1 xe không chở quá 1 cont 40 và 2 cont 20)
        public async Task<int> CountPendingEirsByContainerSizeAndVehicleAsync(string licensePlate, int sizeID)
        {
            return await _context.Eir
                .Where(e => e.LicensePlate == licensePlate && e.Container.SizeID == sizeID && e.Approvements == null)
                .CountAsync();
        }
        //đếm số eir theo container number
        public async Task<int> CountPendingEirsByContainerNumberAsync(string containerNumber)
        {
            return await _context.Eir
                .CountAsync(e => e.ContainerNumber == containerNumber && e.Approvements == null);
        }
        //create
        public async Task<Eir> CreateEirAsync(Eir eir, CancellationToken cancellationToken)
        {
            _context.Eir.Add(eir);
            await _context.SaveChangesAsync(cancellationToken);
            return eir;
        }
        // lấy eir theo id
        public async Task<Eir?> GetEirByIdAsync(int eirNumber)
        {
            return await _context.Set<Eir>().FindAsync(eirNumber);
        }
        //cập nhật eir
        public async Task<Eir> UpdateAsync(Eir eir)
        {
            _context.Entry(eir).State = EntityState.Modified; // Đánh dấu thực thể là đã sửa đổi
            await _context.SaveChangesAsync(); // Lưu các thay đổi
            return eir;
        }
        //tìm eir theo cont
        public async Task<Eir?> GetEirByContainerNumberAsync(string containerNumber)
        {
            return await _context.Eir
                .Where(e => e.ContainerNumber == containerNumber)
                .FirstOrDefaultAsync();
        }
    }
}
