using System.ComponentModel.DataAnnotations.Schema;

namespace Developer_Test_GICREPS.Application.Common.Entities

{
    [Table("Actuals")]
    public class Actual
    {
        public double State { get; set; }
        public double ActualPopulation { get; set; }
        public double ActualHouseholds { get; set; }
    }
}
