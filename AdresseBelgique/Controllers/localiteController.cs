using AdresseBelgique.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdresseBelgique.Controllers
{
    public class localiteController : Controller
    {
        Query query = new Query();
        MyDbContext context = new MyDbContext();
        public string url = "http://geoservices.wallonie.be/geolocalisation/rest/getListeLocalites/";
        // GET: localite
        public ActionResult AllLocalites()
        {
            List<LocaliteService> list = query.GetLocalites(url);
            query.synchronisationLocalite(list);
            List<Localite> localites = context.Localites.ToList();
            return View(localites);
        }
    }
}