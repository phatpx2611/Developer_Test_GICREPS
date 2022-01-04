using Developer_Test_GICREPS.Application.Common.Entities;
using Developer_Test_GICREPS.Application.Common.Interfaces;
using Developer_Test_GICREPS.Application.Common.Interfaces.Infratructure;

namespace Developer_Test_GICREPS.Application
{
    public class ActualService : IActualService
    {
        private readonly IActualDataService _actualDataService;

        public ActualService(IActualDataService actualDataService)
        {
            _actualDataService = actualDataService;
        }

        public async Task<List<Actual>> GetByState(double state)
        {
            return await _actualDataService.GetByState(state);
        }
    }
}
