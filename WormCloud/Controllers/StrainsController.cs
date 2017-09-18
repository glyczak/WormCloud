using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WormCloud.Models;

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

        // GET /strains
        public ActionResult Index()
        {
            var strains = _context.Strains.ToList();
            return View(strains);
        }
    }
}