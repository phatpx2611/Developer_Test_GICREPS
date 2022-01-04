using Developer_Test_GICREPS.Application.Common.Entities;
using Developer_Test_GICREPS.Application.Common.Interfaces.Infratructure;
using Microsoft.EntityFrameworkCore;

namespace Developer_Test_GICREPS.Infrastructure.Persistence
{
    public class ActualDataService : IActualDataService
    {
        private readonly GicContext _context;

        public ActualDataService(GicContext context)
        {
            _context = context;
        }

        public async Task<List<Actual>> GetByState(double state)
        {
            return await _context.Actuals
                .AsNoTracking()
                .Where(x => x.State == state)
                .ToListAsync();
        }
    }
}
