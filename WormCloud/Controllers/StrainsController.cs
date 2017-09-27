using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WormCloud.Models;
using WormCloud.ViewModels;

namespace WormCloud.Controllers
{
    public class StrainsController : Controller
    {
        private ApplicationDbContext _context;

        public StrainsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET /strains/view/{id}
        public ActionResult View(int id)
        {
            var strain = _context.Strains.Include("Species").SingleOrDefault(m => m.Id == id);
            if (strain == null)
                return HttpNotFound();
            return View(strain);
        }

        // GET /strains/new
        public ViewResult New()
        {
            var viewModel = new StrainFormViewModel(_context.Species.ToList());
            return View("StrainForm", viewModel);
        }

        // GET /strains/edit
        public ActionResult Edit(int id)
        {
            var strain = _context.Strains.SingleOrDefault(m => m.Id == id);
            if (strain == null)
                return HttpNotFound();
            var viewModel = new StrainFormViewModel(strain, _context.Species.ToList());
            return View("StrainForm", viewModel);
        }

        // POST /strains/save
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Strain strain, string referrer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new StrainFormViewModel(strain, _context.Species.ToList());
                return View("StrainForm", viewModel);
            }
            if (strain.Id == 0)
            {
                _context.Strains.Add(strain);
            }
            else
            {
                var existingStrain = _context.Strains.Single(m => m.Id == strain.Id);
                existingStrain.SpeciesId = strain.SpeciesId;
                existingStrain.Name = strain.Name;
                existingStrain.Source = strain.Source;
                existingStrain.Genotype = strain.Genotype;
                existingStrain.Notes = strain.Notes;
            }
            _context.SaveChanges();
            if (string.IsNullOrWhiteSpace(referrer))
            {
                return RedirectToAction("Index");
            } else
            {
                return Redirect(referrer);
            }
        }

        // GET /strains
        public ViewResult Index()
        {
            return View();
        }
    }
}