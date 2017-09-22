using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WormCloud.Models;

namespace WormCloud.Dtos
{
    public class SampleDto
    {
        public int Id { get; set; }

        public int StrainId { get; set; }

        public int Box { get; set; }

        [Required]
        public string Location { get; set; }

        public bool CheckedOut { get; set; }

        public string Notes { get; set; }
    }
}