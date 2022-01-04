using Developer_Test_GICREPS.Application.Common.Entities;

namespace Developer_Test_GICREPS.Application.Common.Interfaces
{
    public interface IActualService
    {
        Task<List<Actual>> GetByState(double states);
    }
}
