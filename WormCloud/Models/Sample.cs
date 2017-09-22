using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WormCloud.Models
{
    public class Sample
    {
        public int Id { get; set; }

        public Strain Strain { get; set; }

        public int StrainId { get; set; }

        public int Box { get; set; }

        [Required]
        public string Location { get; set; }

        public bool CheckedOut { get; set; }

        public string Notes { get; set; }
    }
}