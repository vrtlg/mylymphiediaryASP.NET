using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;

namespace MLD.Models
{
    public class Repository
    {
        private readonly AppDbContext _appDbContext; // _ = private
        public Repository (AppDbContext dbInstance){
            _appDbContext = dbInstance; 
        }

        public List<LymphSite> UserLymphSites(string userId)
        {
           // var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            //  var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return new List<LymphSite>(
                _appDbContext.LymphSites.ToList().Where(x => x.UserId == userId) //ToList()
            );
        }

        public LymphSite GetLymphSiteById(int Id)
        {
            return _appDbContext.LymphSites.First(x => x.Id == Id); // would be FirstOrDefault but there wouldn't be a case where LymphSiteId didn't exist in this example
        }

        public List<LymphSite> GetAffectedLymphSites(string userId)
        {

            return new List<LymphSite>(
                _appDbContext.LymphSites.Where(x => x.IsAffected).Where(x => x.UserId == userId)
                );
        }

        //public User GetUserById(int Id)
        //{
        //    return _appDbContext.Users.First(x => x.Id == Id);
        //}

        public List<Measurement> GetMeasurementByDate(DateTime MeasurementDate)
        {
            return new List<Measurement>(
                _appDbContext.Measurements.Where(x => x.MeasurementDate == MeasurementDate)
                ); 

            //WHERE is for returning MULTIPLE instances
            //First and/or FirstOrDefault is for a SINGLE instance
        }

        public string MeasurementDateString(DateTime MeasurementDate)
        {
            return MeasurementDate.ToString();
        }

        //--------------------------------------------
        public List<Measurement> GetAllMeasurements()
        {
            return new List<Measurement>(
                _appDbContext.Measurements.ToList()
                );
        }

        public List<Measurement> MeasurementsForLymphSite(int LymphSiteId)
        {
            return new List<Measurement>(
                _appDbContext.Measurements.Where(x => x.LymphSiteId == LymphSiteId).OrderBy(x => x.MeasurementDate)
                );
        }

        //------------------------------------------------------
        public Measurement GetMeasurementById(int Id)
        {
            return _appDbContext.Measurements.First(x => x.Id == Id); // would be FirstOrDefault but there wouldn't be a case where LymphSiteId didn't exist in this example
        }

        public List<Circumference> GetCircumference(int MeasurementId)
        {
                return new List<Circumference>(
                _appDbContext.Circumferences.Where(x => x.MeasurementId == MeasurementId)
                );
        }

    }
}
