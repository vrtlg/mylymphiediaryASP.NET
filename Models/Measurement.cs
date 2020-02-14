using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MLD.Models
{
    public class Measurement
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a measurement date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime MeasurementDate { get; set; }

        [Required]
        public List<Circumference> Circumferences { get; set; }

        public int UserId { get; set; }

        [Required(ErrorMessage = "There is no Lymph Site associated with this measurement")]
        public int LymphSiteId { get; set; }
    }
}
