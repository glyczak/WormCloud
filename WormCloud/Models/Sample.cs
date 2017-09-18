using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WormCloud.Models
{
    public class Sample
    {
        public int Id { get; set; }

        public Strain Strain { get; set; }

        public int StrainId { get; set; }

        public string CreatedBy { get; set; }

        public bool CheckedOut { get; set; }

        public string Notes { get; set; }
    }
}