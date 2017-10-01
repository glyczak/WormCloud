using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using AutoMapper;
using WormCloud.Dtos;
using WormCloud.Models;

namespace WormCloud.Controllers.Api
{
    public class SamplesController : ApiController
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

        // GET /api/samples
        [AllowAnonymous]
        public IEnumerable<SampleDto> GetSamples()
        {
            return _context.Samples.Include("Strain").ToList().Select(Mapper.Map<Sample, SampleDto>);
        }

        // GET /api/samples?strainId={strainId}
        [AllowAnonymous]
        public IHttpActionResult GetSamples(int strainId)
        {
            var strain = _context.Strains.SingleOrDefault(m => m.Id == strainId);
            if (strain == null)
                return NotFound();
            var samples = _context.Samples.Where(m => m.StrainId == strainId).Select(Mapper.Map<Sample, SampleDto>).ToList();
            return Ok(samples);
        }

        // GET /api/samples/{id}/togglestatus
        [HttpGet]
        [AllowAnonymous]
        public void ToggleStatus(int id)
        {
            var sample = _context.Samples.SingleOrDefault(m => m.Id == id);
            if (sample == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            sample.CheckedOut = !sample.CheckedOut;
            _context.SaveChanges();
        }

        // DELETE /api/samples/{id}
        [Authorize(Roles = RoleName.CanManageSamples)]
        public void DeleteSample(int id)
        {
            var existingSample = _context.Samples.SingleOrDefault(m => m.Id == id);

            if (existingSample == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Samples.Remove(existingSample);
            _context.SaveChanges();
        }
    }
}
