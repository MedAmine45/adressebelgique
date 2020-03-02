using AdresseBelgique.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdresseBelgique.Controllers
{
    public class rueController : Controller
    {
        Query query = new Query();
        MyDbContext context = new MyDbContext();
        public string link = "http://geoservices.wallonie.be/geolocalisation/rest/getListeRuesByCommune/";
        // GET: rue
        public ActionResult GetRues(string commune)
        {
            
            List<RueService> list = query.GetRues(link, commune);
            query.synchronisationRue(list);
            IEnumerable<Rue> rues = from rue in context.Rues.ToList()
                                    where rue.Commune == ( (commune != null) ? commune.ToUpper() : commune) 
                                    //orderby rue.NomRue
                                    select rue;
            //commune = Request.QueryString.Get("commune");

            return View(rues);
        }
    }
}