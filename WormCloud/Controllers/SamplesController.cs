using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WormCloud.Models;
using WormCloud.ViewModels;

namespace WormCloud.Controllers
{
    public class SamplesController : Controller
    {
        private ApplicationDbContext _context;

        public SamplesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET /samples/new?strainId={strainId}
        [Authorize(Roles = RoleName.CanManageSamples)]
        public ActionResult New(int strainId)
        {
            var strain = _context.Strains.SingleOrDefault(m => m.Id == strainId);
            if (strain == null)
                return HttpNotFound();
            var sample = new Sample
            {
                StrainId = strain.Id,
                CheckedOut = false
            };
            return View("SamplesForm", sample);
        }

        // GET /samples/edit/{id}
        [Authorize(Roles = RoleName.CanManageSamples)]
        public ActionResult Edit(int id)
        {
            var sample = _context.Samples.SingleOrDefault(m => m.Id == id);
            if (sample == null)
                return HttpNotFound();
            return View("SamplesForm", sample);
        }

        // POST /samples/save
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageSamples)]
        public ActionResult Save(Sample sample, string referrer)
        {
            if (!ModelState.IsValid)
                return View("SamplesForm", sample);
            if (sample.Id == 0)
                _context.Samples.Add(sample);
            else
            {
                var existingSample = _context.Samples.Single(m => m.Id == sample.Id);
                existingSample.Box = sample.Box;
                existingSample.Location = sample.Location;
                existingSample.Notes = sample.Notes;
            }
            _context.SaveChanges();
            return Redirect(referrer);
        }

        // GET /samples
        public ActionResult Index()
        {
            var samples = _context.Samples.ToList();
            return View(samples);
        }
    }
}