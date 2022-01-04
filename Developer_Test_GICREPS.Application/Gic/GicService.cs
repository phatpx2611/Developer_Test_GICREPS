using Developer_Test_GICREPS.Application.Common.Entities;
using Developer_Test_GICREPS.Application.Common.Interfaces;
namespace Developer_Test_GICREPS.Application
{
    public class GicService : IGicService
    {
        private readonly IActualService _actualService;
        private readonly IEstimateService _estimateService;

        public GicService(IActualService actualService, IEstimateService estimateService)
        {
            _actualService = actualService;
            _estimateService = estimateService;
        }

        public async Task<GicDto> GetGicData(string type, string state)
        {
            GicDto gicDto = null;
            if (string.IsNullOrEmpty(type) || string.IsNullOrEmpty(state)) return gicDto;
            List<string> states = state.Split(",").ToList();
            switch (type.ToUpper())
            {
                case Constants.Population:
                    {
                        gicDto = new GicDto(await GetPopulation(states), null);
                        break;
                    }
                case Constants.HouseHolds:
                    {
                        gicDto = new GicDto(null, await GetHouseHold(states));
                        break;
                    }
                default: return null;
            }
            return gicDto;
        }

        public async Task<List<HouseholdDto>> GetHouseHold(List<string> stateStrings)
        {
            List<double> states = ConvertStringToDouble(stateStrings);
            List<HouseholdDto> houseHolds = new List<HouseholdDto>();
            foreach (var item in states)
            {
                var actual = await _actualService.GetByState(item);
                if (actual.Any())
                {
                    houseHolds.Add(new HouseholdDto(item, actual.FirstOrDefault().ActualHouseholds));
                }
                else
                {
                    double countEstimate = await CountEstimatesAsync(item,Constants.HouseHolds);
                    houseHolds.Add(new HouseholdDto(item, countEstimate));
                }
            }
            return houseHolds;
        }

        public async Task<List<PopulationDto>> GetPopulation(List<string> stateStrings)
        {
            List<double> states = ConvertStringToDouble(stateStrings);
                List<PopulationDto> populations = new List<PopulationDto>();
            foreach (var item in states)
            {
                var actual = await _actualService.GetByState(item);
                if (actual.Any())
                {
                    populations.Add(new PopulationDto(item, actual.FirstOrDefault().ActualPopulation));
                }
                else
                {
                    double countEstimate = await CountEstimatesAsync(item, Constants.Population);
                    populations.Add(new PopulationDto(item, countEstimate));
                }
            }
            return populations;
        }
        private List<double> ConvertStringToDouble(List<string> states)
        {
            List<double> vs = new List<double>();
            foreach (var item in states)
            {
                if (double.TryParse(item, out double s))
                {
                    vs.Add(s);
                }
                else return null;
            }
            return vs;
        }
        private async Task<double> CountEstimatesAsync(double state, string type)
        {
            var estimates = await _estimateService.GetByState(state);
            if (estimates.Any())
            {
                double countEstimate = 0;
                foreach (var i in estimates)
                {
                    switch (type)
                    {
                        case Constants.Population:
                            {
                                countEstimate += i.EstimatesPopulation;
                                break;
                            }
                        case Constants.HouseHolds:
                            {
                                countEstimate += i.EstimatesHouseholds;
                                break;
                            }
                    }
                }
                return countEstimate;
            }
            return 0;
        }
    }
}
