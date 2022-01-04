using Developer_Test_GICREPS.Application.Common.Entities;

namespace Developer_Test_GICREPS.Application.Common.Interfaces.Infratructure
{
    public interface IActualDataService
    {
        Task<List<Actual>> GetByState(double state);
    }
}
