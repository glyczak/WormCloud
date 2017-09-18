using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WormCloud.Models;

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

        // GET /samples
        public ActionResult Index()
        {
            var samples = _context.Samples.ToList();
            return View(samples);
        }
    }
}