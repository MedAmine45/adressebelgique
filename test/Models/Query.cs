using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace test.Models
{
    public class Query
    {
        public Query()
        {

        }

        /// <summary>
        /// return list of Communes
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public List<Commune> GetCommunes(string url)
        {
            if (string.IsNullOrEmpty(url)) throw new Exception("URL param in GetCommuns Method is Null");
            List<Commune> communes = new List<Commune>();
            try
            {
                string response = ReturnJsonFromService(url);
                if (response == "Bad Result") return null;
                Communes data = JsonConvert.DeserializeObject<Communes>(response);
                foreach (var item in data.communes)
                {
                    Commune commune = new Commune();
                  
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

        public string ReturnJsonFromService(string url)
        {
            
            string response = string.Empty;
            var client = new System.Net.WebClient();
            response = client.DownloadString(url);
            return response;
        }
        public void WriteToConsole(List<Commune> list)
        {
            Console.WriteLine("{0} communes found :", list.Count);
            for (int i = 0; i < list.Count; i++)
            { 
                Console.WriteLine("Commun N° {0}",i+1);
                Console.WriteLine("le nom de la commune:{0}", list[i].nom);
                for (int j = 0; j < list[i].cps.Count(); j++)
                {
                    Console.WriteLine(list[i].cps[j]);
                }
                Console.WriteLine("les dimensions de la commune : xMin = {0}  , xMax= {1}  ,  yMin = {2} ,yMax =  {3}", list[i].xMin, list[i].xMax, list[i].yMin, list[i].yMax);
            }
            Console.WriteLine();
        }
        /// <summary>
        /// return list of streets
        /// </summary>
        /// <param name="url" nameregion="namecommune"></param>
        /// <returns></returns>
        public List<Rue> GetRues(string url ,string namecommune)
        {
            if (string.IsNullOrEmpty(url) && string.IsNullOrEmpty(namecommune)) throw new Exception("URL param in GetCommuns Method is Null");
            List<Rue> rues = new List<Rue>();
            try
            {
                string response = ReturnJsonFromServiceRue(url, namecommune);
                if (response == "Bad Result") return null;
                Rues data = JsonConvert.DeserializeObject<Rues>(response);
                foreach (var item in data.rues)
                {
                    Rue rue = new Rue();

                    rue.nom = item.nom;
                    rue.commune = item.commune;
                    rue.xMin = item.xMin;
                    rue.xMax = item.xMax;
                    rue.yMin = item.yMin;
                    rue.yMax = item.yMax;
                    rue.cps = item.cps;

                    rues.Add(rue);

                }


            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);

            }
            return rues;
        }

        public string ReturnJsonFromServiceRue(string url,string commune)
        {

            string response = string.Empty;
            var client = new System.Net.WebClient();
            response = client.DownloadString(url+commune+"/");
            return response;
        }

        public void WriteToConsoleRue(List<Rue> list)
        {
            Console.WriteLine("{0} rue trouvée: ", list.Count);
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine("rue N° {0}", i + 1);
                Console.WriteLine("le nom de la rue:{0}", list[i].nom);
                for (int j = 0; j < list[i].cps.Count(); j++)
                {
                    Console.WriteLine(list[i].cps[j]);
                }
                Console.WriteLine("cette rue est dans la commune : "+list[i].commune);
                Console.WriteLine("les dimensions de la rue : xMin = {0}  , xMax= {1}  ,  yMin = {2} ,yMax =  {3}", list[i].xMin, list[i].xMax, list[i].yMin, list[i].yMax);
            }
            Console.WriteLine();
        }
    }
}
