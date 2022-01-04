using Developer_Test_GICREPS.Application.Common.Entities;

namespace Developer_Test_GICREPS.Application.Common.Interfaces
{
    public interface IGicService
    {
        Task<List<PopulationDto>> GetPopulation(List<string> states);
        Task<List<HouseholdDto>> GetHouseHold(List<string> states);
        Task<GicDto> GetGicData(string type, string state);

    }

}
