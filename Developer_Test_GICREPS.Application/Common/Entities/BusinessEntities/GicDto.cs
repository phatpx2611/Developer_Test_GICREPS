namespace Developer_Test_GICREPS.Application.Common.Entities
{
    public class GicDto
    {
        public List<PopulationDto> Populations { get; set; }    
        public List<HouseholdDto> Households { get; set; }

        public GicDto(List<PopulationDto> populations, List<HouseholdDto> households)
        {
            this.Populations = populations;
            this.Households = households;
        }
    }

}
