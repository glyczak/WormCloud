using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WormCloud.Models;

namespace WormCloud.ViewModels
{
    public class StrainFormViewModel
    {
        public StrainFormViewModel(IEnumerable<Species> species)
        {
            Strain = new Strain();
            Species = species;
        }
        public StrainFormViewModel(Strain strain, IEnumerable<Species> species)
        {
            Strain = strain;
            Species = species;
        }
        public Strain Strain { get; set; }
        public IEnumerable<Species> Species { get; set; }
    }
}