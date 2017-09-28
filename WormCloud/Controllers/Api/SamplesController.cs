using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
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
        public IEnumerable<SampleDto> GetSamples()
        {
            return _context.Samples.ToList().Select(Mapper.Map<Sample, SampleDto>);
        }

        // GET /api/samples?strainId={strainId}
        public IHttpActionResult GetSamples(int strainId)
        {
            var strain = _context.Strains.SingleOrDefault(m => m.Id == strainId);
            if (strain == null)
                return NotFound();
            var samples = _context.Samples.Where(m => m.StrainId == strainId).Select(Mapper.Map<Sample, SampleDto>).ToList();
            return Ok(samples);
        }

        // GET /api/samples/{id}/togglestatus
        [System.Web.Http.HttpGet]
        public void ToggleStatus(int id)
        {
            var sample = _context.Samples.SingleOrDefault(m => m.Id == id);
            if (sample == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            sample.CheckedOut = !sample.CheckedOut;
            _context.SaveChanges();
        }

        // DELETE /api/samples/{id}
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
