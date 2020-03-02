using AdresseBelgique.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdresseBelgique.Controllers
{
    public class addressController : Controller
    {
        Query query = new Query();
        MyDbContext context = new MyDbContext();
        public string url = "http://geoservices.wallonie.be/geolocalisation/rest/getListeCommunes/";
        // GET: address
        public ActionResult Index()
        {
            List<CommuneService> list = query.GetCommunes(url);
            query.synchronisation(list);
            List<Commune> communes = context.Communes.ToList();
            return View(communes);
        }
    }
}