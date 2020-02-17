using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MLD.Models
{
    public class LymphSite
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MaxMeasuringPoints { get; set; }
        public bool IsAffected { get; set; }
        public int NumMeasuringPoints { get; set; }
        public string UserId { get; set; }
    }
}
