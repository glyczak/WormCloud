using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
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
        [Authorize(Roles = RoleName.CanManageStrains)]
        public ViewResult New()
        {
            var viewModel = new StrainFormViewModel(_context.Species.ToList());
            return View("StrainForm", viewModel);
        }

        // GET /strains/edit/{id}
        [Authorize(Roles = RoleName.CanManageStrains)]
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
        [Authorize(Roles = RoleName.CanManageStrains)]
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

        [HttpGet]
        [Authorize(Roles = RoleName.CanManageStrains)]
        public ActionResult Import()
        {
            return View(new List<string>());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageStrains)]
        public ActionResult Import(HttpPostedFileBase file)
        {
            var model = new List<string>();
            if (file.ContentLength > 0)
            {
                string filePath = Path.Combine(HttpContext.Server.MapPath("~/App_Data/Uploads"),
                    Path.GetFileName(file.FileName));
                file.SaveAs(filePath);
                DataSet ds = new DataSet();

                //A 32-bit provider which enables the use of

                string ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath +
                                          ";Extended Properties=Excel 12.0;";

                using (OleDbConnection conn = new System.Data.OleDb.OleDbConnection(ConnectionString))
                {
                    conn.Open();
                    using (DataTable dtExcelSchema = conn.GetSchema("Tables"))
                    {
                        string sheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
                        string query = "SELECT * FROM [" + sheetName + "]";
                        OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn);
                        //DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        if (ds.Tables.Count > 0)
                        {
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                                {
                                    _context.Strains.Add(new Strain
                                    {
                                        SpeciesId = 1,
                                        Name = ds.Tables[0].Rows[i].ItemArray[0].ToString(),
                                        Genotype = ds.Tables[0].Rows[i].ItemArray[1].ToString()
                                    });
                                }
                                _context.SaveChanges();
                            }
                        }
                    }
                }
            }

            return RedirectToAction("Index");
        }
    }
}