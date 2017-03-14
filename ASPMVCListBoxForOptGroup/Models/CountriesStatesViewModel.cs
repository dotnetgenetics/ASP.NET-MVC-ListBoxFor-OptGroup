using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPMVCListBoxForOptGroup.Models
{
    public class CountriesStatesViewModel
    {
        public IEnumerable<string> SelectedStates { get; set; }
        public Dictionary<string, IEnumerable<SelectListItem>> CountriesAndStates { get; set; }
    }
}