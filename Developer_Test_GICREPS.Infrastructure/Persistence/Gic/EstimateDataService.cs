using Developer_Test_GICREPS.Application.Common.Entities;
using Developer_Test_GICREPS.Application.Common.Interfaces.Infratructure;
using Microsoft.EntityFrameworkCore;

namespace Developer_Test_GICREPS.Infrastructure.Persistence
{
    public class EstimateDataService : IEstimateDataService
    {

        private readonly GicContext _context;

        public EstimateDataService(GicContext context)
        {
            _context = context;
        }
        public async Task<List<Estimate>> GetByState(double state)
        {
            return await _context.Estimates
                         .AsNoTracking()
                         .Where(x => x.State == state)
                         .ToListAsync();
        }
    }
}
