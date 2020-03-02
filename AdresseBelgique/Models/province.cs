using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdresseBelgique.Models
{
    public class Province
    {
        public string datasetid { get; set; }
        public string recordid { get; set; }

    }

    public class Fields
    {
        public string province { get; set; }
        public string communeprincipale { get; set; }
        public string localite { get; set; }
        public string codepostal { get; set; }
        public string souscommune { get; set; }

    }
}