using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MLD.Models;
using MLD.ViewModels;

namespace MLD.Controllers
{
    [Authorize]
    public class MeasurementController : Controller
    {
        private readonly Repository _repository;
        private readonly AppDbContext _appDbContext;

        public MeasurementController(Repository repository, AppDbContext appDbContext)
        {
            _repository = repository;
            _appDbContext = appDbContext;
        }

        public IActionResult New(string LymphSiteId, int Id)
        {
            var measurement = _appDbContext.Measurements.FirstOrDefault(x => x.Id == Convert.ToInt32(Id));
            if (measurement == null)
            {
                measurement = new Measurement
                {
                    Id = 1
                };
            }
            ViewBag.Id = measurement.Id;
            ViewBag.LymphSiteId = LymphSiteId;
            ViewBag.LymphSiteName = _appDbContext.LymphSites.First(x => x.Id == Convert.ToInt32(LymphSiteId)).Name;
            ViewBag.NumMeasuringPoints = _appDbContext.LymphSites.First(x => x.Id == Convert.ToInt32(LymphSiteId)).NumMeasuringPoints;
            return View(measurement);
        }

        [HttpPost]
        public IActionResult Create(Measurement measurement) 
        {
            if (ModelState.IsValid)
            {
                _appDbContext.Measurements.Add(measurement);
                _appDbContext.SaveChanges();
                return RedirectToAction("All", measurement);
            }
            else
            {
                //ModelState.AddModelError("","An error occurred :(");
                return View("New", measurement); // NEEDS TO HAVE ERROR MESSAGES
            };
        }
        //-----------------------------------------------
        public IActionResult Show(int Id, string LymphSiteId)
        {

            var measurement = _repository.GetMeasurementById(Id);

            ViewBag.Id = measurement.Id;
            ViewBag.LymphSiteId = LymphSiteId;
            ViewBag.LymphSiteName = _appDbContext.LymphSites.First(x => x.Id == Convert.ToInt32(LymphSiteId)).Name;
            ViewBag.NumMeasuringPoints = _appDbContext.LymphSites.First(x => x.Id == Convert.ToInt32(LymphSiteId)).NumMeasuringPoints;

            ViewBag.NumCircumferences = _repository.GetCircumference(Id).Count();
            if (measurement == null)
            {
                return NotFound();
            }
            else
            {
                return View(measurement);
            }
        }

        [HttpPost]
        [ActionName("Update")]
        public IActionResult Update(Measurement measurement)
        {
            _appDbContext.Measurements.Update(measurement);
            _appDbContext.SaveChanges();
            return RedirectToAction("All", measurement);
        }

        public IActionResult Index()
        {
            LymphSiteViewModel lymphSiteViewModel = new LymphSiteViewModel
            {
                Measurements = _repository.GetAllMeasurements()
            };
            return View(lymphSiteViewModel);
        }

        public IActionResult All(int LymphSiteId)
        {
            ViewBag.LymphSiteId = LymphSiteId;
            ViewBag.LymphSiteName = _appDbContext.LymphSites.First(x => x.Id == Convert.ToInt32(LymphSiteId)).Name;
            ViewBag.NumMeasuringPoints = _appDbContext.LymphSites.First(x => x.Id == Convert.ToInt32(LymphSiteId)).NumMeasuringPoints;
            LymphSiteViewModel lymphSiteViewModel = new LymphSiteViewModel
            {
                Measurements = _repository.MeasurementsForLymphSite(LymphSiteId)
            };

            for (int i = 0; i < lymphSiteViewModel.Measurements.Count; i++)
            {
                int Id = lymphSiteViewModel.Measurements[i].Id;
                lymphSiteViewModel.Measurements[i].Circumferences = new List<Circumference>( _repository.GetCircumference(Id));
            }

            return View(lymphSiteViewModel);
        }

        [HttpGet]
        [ActionName("Delete")]
        public IActionResult Delete(int Id)
        {
            var measurement = _repository.GetMeasurementById(Id);
            _appDbContext.Measurements.Remove(measurement);
            _appDbContext.SaveChanges();
            return RedirectToAction("All", measurement);
        }
    }
}