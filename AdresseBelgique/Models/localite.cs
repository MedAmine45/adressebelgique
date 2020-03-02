using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AdresseBelgique.Models
{
    [Table("Localite")]
    public class Localite
    {
        [Key]
        public int LocaliteID { get; set; }
        public string Localitenom { get; set; }
        public string Commune { get; set; }
        public int Cps { get; set; }
        public double xMin { get; set; }
        public double xMax { get; set; }
        public double yMin { get; set; }
        public double yMax { get; set; }

    }
    public class Localites
    {
       public LocaliteService[] localites { get; set; }
    }
    public class LocaliteService
    {
        public string nom { get; set; }
        public string Commune { get; set; }
        public int[] Cps { get; set; }
        public double xMin { get; set; }
        public double xMax { get; set; }
        public double yMin { get; set; }
        public double yMax { get; set; }

    }






}