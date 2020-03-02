using AdresseBelgique.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdresseBelgique.Controllers
{
    public class codePostalController : Controller
    {
        Query query = new Query();
        MyDbContext context = new MyDbContext();
        public string link = "http://geoservices.wallonie.be/geolocalisation/rest/getListeRuesByCp/";
        // GET: CodePostal
        public ActionResult Index(int? codepostal)
        {
            List<RueService> list = query.GetRues(link, codepostal.ToString());
            query.synchronisationRue(list);
            IEnumerable<Rue> rues = from rue in context.Rues.ToList()
                                    where rue.Cps == codepostal
                                    orderby rue.NomRue
                                    select rue;
            return View(rues);
        }
    }
}