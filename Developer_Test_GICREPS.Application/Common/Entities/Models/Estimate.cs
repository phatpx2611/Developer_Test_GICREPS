using System.ComponentModel.DataAnnotations.Schema;

namespace Developer_Test_GICREPS.Application.Common.Entities
{
    [Table("Estimates")]
    public class Estimate : BaseEntity
    {
        public double State { get; set; }
        public double Districts { get; set; }
        public double EstimatesPopulation { get; set; }
        public double EstimatesHouseholds { get; set; }
    }
}
