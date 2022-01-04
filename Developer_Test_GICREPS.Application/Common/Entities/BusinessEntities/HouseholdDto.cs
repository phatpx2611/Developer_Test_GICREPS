namespace Developer_Test_GICREPS.Application.Common.Entities
{
    public class HouseholdDto
    {
        public double State { get; set; }
        public double Household { get; set; }

        public HouseholdDto(double state, double household)
        {
            State = state;
            Household = household;
        }
    }

}
