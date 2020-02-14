using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MLD.Models;
using MLD.ViewModels;

namespace MLD.Controllers
{
    public class LymphSiteController : Controller
    {
        private readonly Repository _repository;
        private readonly AppDbContext _appDbContext;
        public LymphSiteController(Repository repository, AppDbContext appDbContext) 
        {
            _repository = repository;
            _appDbContext = appDbContext;
        }

        public IActionResult Index()
        {
            LymphSiteViewModel lymphSiteViewModel = new LymphSiteViewModel
            {
                LymphSites = _repository.AllLymphSites()
            };
            return View(lymphSiteViewModel);
        }

        public IActionResult Show(int Id)
        {
            var lymphsite = _repository.GetLymphSiteById(Id);
            if (lymphsite == null)
            {
                return NotFound();
            }
            else
            {
                return View(lymphsite);
            }
            
        }

        public IActionResult AffectedSites()
        {
            LymphSiteViewModel lymphSiteViewModel = new LymphSiteViewModel
            {
                LymphSites = _repository.GetAffectedLymphSites()
            };
            return View(lymphSiteViewModel);
        }

        [HttpPost]
        [ActionName("AffectedSites")]
        public IActionResult Update(List<LymphSite> LymphSites)
        {
            foreach (var lymphsite in LymphSites)
            {
                _appDbContext.LymphSites.Update(lymphsite);
                _appDbContext.SaveChanges();
            }
            return RedirectToAction("AffectedSites");
        }
    }
}