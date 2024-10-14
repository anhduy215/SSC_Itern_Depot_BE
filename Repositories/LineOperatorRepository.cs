using Entity;

namespace DepotBackEnd.Repositories
{
    public class LineOperatorRepository
    {
        private readonly Database _context;

        public LineOperatorRepository(Database context)
        {
            _context = context;
        }

        public async Task<LineOperator?> GetLineOperatorByIdAsync(int lineOperatorId)
        {
            return await _context.LineOperators.FindAsync(lineOperatorId);
        }
    }
}
