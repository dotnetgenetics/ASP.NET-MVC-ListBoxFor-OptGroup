using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASPMVCListBoxForOptGroup.Models;

namespace ASPMVCListBoxForOptGroup.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            CountriesStatesViewModel model = new CountriesStatesViewModel();
            Dictionary<string, IEnumerable<SelectListItem>> items = new Dictionary<string, IEnumerable<SelectListItem>>();            
            model.CountriesAndStates = new Dictionary<string, IEnumerable<SelectListItem>>();

            items.Add("US", new List<SelectListItem>()
            {
               new SelectListItem(){ Text = "Arizona", Value = "001", Selected = false},
               new SelectListItem(){ Text = "Montana", Value = "002", Selected = false}
            });

            items.Add("AU", new List<SelectListItem>()
            {
               new SelectListItem(){ Text = "Queensland", Value = "003", Selected = false},
               new SelectListItem(){ Text = "Victoria", Value = "004", Selected = false}
            });

            items.Add("BR", new List<SelectListItem>()
            {
               new SelectListItem(){ Text = "Bahia", Value = "005", Selected = false},
               new SelectListItem(){ Text = "Minas Gerais", Value = "006", Selected = false}
            });

            model.CountriesAndStates = items;
            return View(model);
        }

        [HttpPost]
        public ActionResult SaveEntry(IEnumerable<string> SelectedStates)
        {
            if (SelectedStates != null)
            {
                if (SelectedStates.Count() > 0)
                {
                    TempData["list"] = SelectedStates.ToList();
                    return RedirectToAction("SelectionSuccess");
                }
            }

            return RedirectToAction("Index");
        }

        public ActionResult SelectionSuccess()
        {
            ViewData["SelectedStates"] = TempData["list"] as List<string>;
            return View();
        }
	}
}