using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http.Headers;
using System.Net.Http;
using Newtonsoft.Json;
namespace AdresseBelgique.Models
{
    public class Query
    {
        public MyDbContext myDbContext = new MyDbContext();
        public void synchronisation(List<CommuneService> list)
        {
           
            int[] listcps;
            foreach(CommuneService item in list)
            {
               Commune commune = new Commune();
               commune.nom = item.nom;
                 
                commune.xMin = item.xMin;
                commune.xMax = item.xMax;
                commune.yMin = item.yMin;
                commune.yMax = item.yMax;
                listcps = item.cps;
                for (int j = 0; j < listcps.Count(); j++)
                {
                    commune.cps = listcps[j];
                    if (!myDbContext.Communes.Any(c => c.nom == item.nom && c.cps == commune.cps))
                    {
                        myDbContext.Communes.Add(commune);
                        myDbContext.SaveChanges();
                    }
                }
               
            }
           
        }
        public string ReturnJsonFromService(string url)
        {
            string response = string.Empty;
            var client = new System.Net.WebClient();
            response = client.DownloadString(url);
            return response;
        }
        /// <summary>
        /// return list of Communes
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public List<CommuneService> GetCommunes(string url)
        {
            if (string.IsNullOrEmpty(url)) throw new Exception("URL param in GetCommuns Method is Null");
            List<CommuneService> communes = new List<CommuneService>();
            try
            {
                string response = ReturnJsonFromService(url);
                if (response == "Bad Result") return null;
                Communes data = JsonConvert.DeserializeObject<Communes>(response);
                foreach (var item in data.communes)
                {
                    CommuneService commune = new CommuneService();

                    commune.nom = item.nom;
                    commune.xMin = item.xMin;
                    commune.xMax = item.xMax;
                    commune.yMin = item.yMin;
                    commune.yMax = item.yMax;
                    commune.cps = item.cps;

                    communes.Add(commune);

                }


            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);

            }
            return communes;

        }

        /// <summary>
        /// return list of streets
        /// </summary>
        /// <param name="url" nameregion="namecommune"></param>
        /// <returns></returns>
        public List<RueService> GetRues(string url, string namecommune)
        {
            if (string.IsNullOrEmpty(url) && string.IsNullOrEmpty(namecommune)) throw new Exception("URL param in GetCommuns Method is Null");
            List<RueService> rues = new List<RueService>();
            try
            {
                string response = ReturnJsonFromServiceRue(url, namecommune);
                if (response == "Bad Result") return null;
                Rues data = JsonConvert.DeserializeObject<Rues>(response);
                foreach (var item in data.rues)
                {
                    RueService rue = new RueService();

                    rue.nom = item.nom;
                    rue.commune = item.commune;
                    rue.xMin = item.xMin;
                    rue.xMax = item.xMax;
                    rue.yMin = item.yMin;
                    rue.yMax = item.yMax;
                    rue.cps = item.cps;
                    rue.localites = item.localites;

                    rues.Add(rue);

                }


            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);

            }
            return rues;
        }
        public string ReturnJsonFromServiceRue(string url, string commune)
        {
            string response = string.Empty;
            var client = new System.Net.WebClient();
            response = client.DownloadString(url + commune + "/");
            return response;
        }

        public void synchronisationRue(List<RueService> list)
        {

            int[] listcps;
            string[] listlocalites;
            foreach (RueService item in list)
            {
                Rue rue = new Rue();
                rue.NomRue = item.nom;
                rue.Commune = item.commune;
                rue.xMin = item.xMin;
                rue.xMax = item.xMax;
                rue.yMin = item.yMin;
                rue.yMax = item.yMax;
                listcps = item.cps;
                listlocalites = item.localites;
                for(int i=0;i< listlocalites.Count(); i++)
                {
                    rue.Localite = listlocalites[i];
                    myDbContext.SaveChanges();
                }

                for (int j = 0; j < listcps.Count(); j++)
                {
                    rue.Cps = listcps[j];
                    if (!myDbContext.Rues.Any(c => c.NomRue == item.nom && c.Cps == rue.Cps && c.Localite == rue.Localite))
                    {
                        myDbContext.Rues.Add(rue);
                        myDbContext.SaveChanges();
                    }
                }

            }

        }

        /// <summary>
        /// return list of Localite
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public List<LocaliteService> GetLocalites(string url)
        {
            if (string.IsNullOrEmpty(url)) throw new Exception("URL param in GetCommuns Method is Null");
            List<LocaliteService> localites = new List<LocaliteService>();
            try
            {
                string response = ReturnJsonFromService(url);
                if (response == "Bad Result") return null;
                Localites data = JsonConvert.DeserializeObject<Localites>(response);
                foreach (var item in data.localites)
                {
                    LocaliteService localite = new LocaliteService();

                    localite.nom = item.nom;
                    localite.Commune = item.Commune;
                    localite.xMin = item.xMin;
                    localite.xMax = item.xMax;
                    localite.yMin = item.yMin;
                    localite.yMax = item.yMax;
                    localite.Cps = item.Cps;

                    localites.Add(localite);

                }


            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);

            }

            return localites;
        }

        public void synchronisationLocalite(List<LocaliteService> list)
        {
            int[] listcps;
            foreach (LocaliteService item in list)
            {
                Localite localite = new Localite();
                localite.Localitenom = item.nom;
                localite.Commune = item.Commune;

                localite.xMin = item.xMin;
                localite.xMax = item.xMax;
                localite.yMin = item.yMin;
                localite.yMax = item.yMax;
                listcps = item.Cps;
                for (int j = 0; j < listcps.Count(); j++)
                {
                    localite.Cps = listcps[j];
                    if (!myDbContext.Localites.Any(l => l.Localitenom == localite.Localitenom && l.Commune == localite.Commune && l.Cps == localite.Cps))
                    {
                        myDbContext.Localites.Add(localite);
                        myDbContext.SaveChanges();
                    }
                }

            }

        }
    }



}