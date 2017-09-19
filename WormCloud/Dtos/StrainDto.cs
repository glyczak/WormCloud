using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WormCloud.Models;

namespace WormCloud.Dtos
{
    public class StrainDto
    {
        public int Id { get; set; }

        public int SpeciesId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Genotype { get; set; }

        public string Notes { get; set; }
    }
}