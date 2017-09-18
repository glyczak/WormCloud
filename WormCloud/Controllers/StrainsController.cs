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

        public ViewResult New()
        {
            var viewModel = new StrainFormViewModel(_context.Species.ToList());
            return View("StrainForm", viewModel);
        }

        // GET /strains
        public ViewResult Index()
        {
            var strains = _context.Strains.ToList();
            return View(strains);
        }
    }
}