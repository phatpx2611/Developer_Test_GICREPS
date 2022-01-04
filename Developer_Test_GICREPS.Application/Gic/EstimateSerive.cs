using Developer_Test_GICREPS.Application.Common.Entities;
using Developer_Test_GICREPS.Application.Common.Interfaces;
using Developer_Test_GICREPS.Application.Common.Interfaces.Infratructure;

namespace Developer_Test_GICREPS.Application
{
    public class EstimateSerive : IEstimateService
    {
        private readonly IEstimateDataService _estimateDataService;

        public EstimateSerive(IEstimateDataService estimateDataService)
        {
            _estimateDataService = estimateDataService;
        }

        public async Task<List<Estimate>> GetByState(double state)
        {
            return await _estimateDataService.GetByState(state);
        }
    }
}
