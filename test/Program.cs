using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test.Models;

namespace test
{
    class Program
    {
        public static string url = "http://geoservices.wallonie.be/geolocalisation/rest/getListeCommunes/";

        public static string link = "http://geoservices.wallonie.be/geolocalisation/rest/getListeRuesByCommune/";
        static void Main(string[] args)
        {

            Query query = new Query();

            #region Serialization d'un objet
            Console.WriteLine("Serialization");
            Commune commune = new Commune { cps = new int[] { 4650, 4651, 4653, 4654, 4652 }, nom = "HERVE", xMin = 246231.029711469, xMax = 255561.7382186, yMin = 143636.73591909, yMax = 155685.253314536,ins = 63035 };
            string result = JsonConvert.SerializeObject(commune);
            Console.WriteLine(result);
            #endregion

            #region Deserlization d'un objet
            Console.WriteLine("\n Deseralization");
            Commune newcommune = JsonConvert.DeserializeObject<Commune>(result);
            Console.WriteLine("les codes postaux sont :");
            foreach (int codepost in newcommune.cps)
            {
                Console.WriteLine(codepost + "\n");
            }
            Console.WriteLine("la commune corresondant est : " + newcommune.nom);
            #endregion

            #region Serialization d'une collection des objets
            Console.WriteLine("\n Serialisation of collection");
            List<Commune> communes = new List<Commune>
            {
                new Commune{cps = new int[] { 4650, 4651, 4653, 4654,4652 }, nom = "HERVE", xMin = 246231.029711469, xMax= 255561.7382186,yMin= 143636.73591909,yMax= 155685.253314536},
                new Commune{cps = new int[] { 1400, 1401, 1404, 1402 }, nom = "NIVELLES", xMin = 141271.869532202, xMax= 152655.986909842,yMin= 136946.530887172,yMax= 147158.961247824},
                new Commune{cps = new int[]{ 4317}, nom = "FAIMES", xMin = 208232.446724861, xMax= 214897.248173163,yMin= 145403.309723394,yMax= 152295.636752398},
                new Commune{cps = new int[] { 1000}, nom = "BRUXELLES", xMin = 146142.907083178, xMax= 154809.445490576,yMin= 165091.313804883,yMax= 178183.796161353  }
            };
          
            string collectionResult = JsonConvert.SerializeObject(communes);
            Console.WriteLine(" \"communes\":"+collectionResult);
            #endregion

            #region Deserlization d'une collection des objets
            Console.WriteLine("\n Deserialisation of collection");
            List<Commune> newcommunes = JsonConvert.DeserializeObject<List<Commune>>(collectionResult);
            foreach (var item in newcommunes)
            {
                Console.WriteLine("le nom de la commune:  " + item.nom);
                for(int i = 0; i < item.cps.Count(); i++)
                {
                    Console.WriteLine(item.cps[i]);
                }

            }
            #endregion

            #region lister les informations de tous les communes
            Console.WriteLine("\n Deserialisation of collection");
            #region Get Communes
            // Get Communes
            Console.WriteLine("Retrieving List of Communs...");
            List<Commune> list = query.GetCommunes(url);
            query.WriteToConsole(list);
            #endregion
            #endregion

            #region lister les informations de tous les rues pour chaque commune
            Console.WriteLine("donnez le nom de la commune");
            string region = Console.ReadLine();
            Console.WriteLine("\n la liste des rues de la commune : " + region);
            List<Rue> listRue = query.GetRues(link, region);
            query.WriteToConsoleRue(listRue);



            #endregion


            Console.ReadLine();
        }
    }
}
