using MLD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MLD.ViewModels
{
    public class LymphSiteViewModel
    {
        public List<LymphSite> LymphSites { get; set; }
        public List<Measurement> Measurements { get; set; }
    }
}
