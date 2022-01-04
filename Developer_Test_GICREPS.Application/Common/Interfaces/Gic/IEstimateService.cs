using Developer_Test_GICREPS.Application.Common.Entities;

namespace Developer_Test_GICREPS.Application.Common.Interfaces
{
    public interface IEstimateService
    {
        Task<List<Estimate>> GetByState(double state);
    }

}
