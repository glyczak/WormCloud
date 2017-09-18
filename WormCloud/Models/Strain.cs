using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mime;
using System.Web;

namespace WormCloud.Models
{
    public class Strain
    {
        public int Id { get; set; }

        public Species Species { get; set; }

        [Display(Name = "Species")]
        public int SpeciesId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Genotype { get; set; }

        public string Notes { get; set; }
    }
}