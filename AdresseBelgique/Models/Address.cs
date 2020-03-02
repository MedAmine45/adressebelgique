using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AdresseBelgique.Models
{
    [Table("Address")]
    public class Address
    {
        [Key]
        public int AddressId { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
    }

    [Table("Commune")]
    public class Commune
    {
        [Key]
        public int CommuneID { get; set; }
        public int cps { get; set; }
        public string nom { get; set; }
        public double xMin { get; set; }
        public double xMax { get; set; }
        public double yMin { get; set; }
        public double yMax { get; set; }

    }
    public class CommuneService
    {

        public int[] cps { get; set; }
        public string nom { get; set; }
        public double xMin { get; set; }
        public double xMax { get; set; }
        public double yMin { get; set; }
        public double yMax { get; set; }

    }
    public class Communes
    {
        public CommuneService[] communes { get; set; }
    }

}