using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AdresseBelgique.Models
{
    [Table("street")]
    public class Rue
    {
        public int RueId { get; set; }
        public int Cps { get; set; }
        public string NomRue { get; set; }
        public string Localite { get; set; }
        public string Commune { get; set; }
        public double xMin { get; set; }
        public double xMax { get; set; }
        public double yMin { get; set; }
        public double yMax { get; set; }

    }
    public class RueService
    {

        public int[] cps { get; set; }
        public string nom { get; set; }
        public string commune { get; set; }
        public string[] localites { get; set; }
        public double xMin { get; set; }
        public double xMax { get; set; }
        public double yMin { get; set; }
        public double yMax { get; set; }

    }
    public class Rues
    {
        public RueService[] rues { get; set; }
    }

}