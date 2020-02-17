using System.ComponentModel.DataAnnotations;

namespace MLD.Models
{
    public class Circumference
    {
        public int Id { get; set; }
        [Required]
        public int PositionFromStart { get; set; }

        [Required]
        [Range(1, 300)]
        public decimal DistanceAround { get; set; }
        public int MeasurementId { get; set; }
    }
}