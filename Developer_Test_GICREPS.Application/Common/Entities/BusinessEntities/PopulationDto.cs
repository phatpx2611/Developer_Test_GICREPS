namespace Developer_Test_GICREPS.Application.Common.Entities
{
    public class PopulationDto
    {
        public double State { get; set; }
        public double Population { get; set; }

        public PopulationDto(double state, double population)
        {
            State = state;
            Population = population;
        }
    }
}
