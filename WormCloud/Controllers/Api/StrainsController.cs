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
    public class StrainsController : ApiController
    {
        private ApplicationDbContext _context;

        public StrainsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/strains
        public IEnumerable<StrainDto> GetStrains()
        {
            return _context.Strains.ToList().Select(Mapper.Map<Strain, StrainDto>);
        }

        // GET /api/strains/{id}
        public IHttpActionResult GetStrain(int id)
        {
            var strain = _context.Strains.SingleOrDefault(m => m.Id == id);
            if (strain == null)
                return NotFound();

            return Ok(Mapper.Map<Strain, StrainDto>(strain));
        }

        // POST /api/strains
        [HttpPost]
        public IHttpActionResult CreateStrain(StrainDto strainDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var strain = Mapper.Map<StrainDto, Strain>(strainDto);
            _context.Strains.Add(strain);
            _context.SaveChanges();

            strainDto.Id = strain.Id;

            return Created(new Uri(Request.RequestUri + "/" + strain.Id), strainDto);
        }

        // PUT /api/strains/{id}
        [HttpPut]
        public void UpdateStrain(int id, StrainDto strainDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var existingStrain = _context.Strains.SingleOrDefault(m => m.Id == id);
            if (existingStrain == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(strainDto, existingStrain);

            _context.SaveChanges();
        }

        // DELETE /api/strains/{id}
        [HttpDelete]
        public void DeleteStrain(int id)
        {
            var existingStrain = _context.Strains.SingleOrDefault(m => m.Id == id);

            if(existingStrain == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Strains.Remove(existingStrain);
            _context.SaveChanges();
        }
    }
}