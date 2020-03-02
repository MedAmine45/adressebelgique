using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.Models
{
    class Address
    {
        public int AddressId { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
    
    }
    public class Communes
    {
        public Commune[] communes { get; set; }
    }

    public class Commune
    {
        public int[] cps { get; set; }
        public string nom { get; set; }
        public double xMin { get; set; }
        public double xMax { get; set; }
        public double yMin { get; set; }
        public double yMax { get; set; }

        public int ins { get; set; }
    }

     public class PostalCode
    {
        public string Value { get;  set; }  
        public string Name { get;  set; }
        public string CountryCode { get;  set; }
        public double Latitude { get;  set; }
        public double Longitude { get;  set; }
        public string Admin1Code { get;  set; }  
        public string Admin1Name  { get ; set; }
        public string Admin2Code { get;  set; }
        public string Admin2Name{ get; set;}
        public string Admin3Code { get; set; }
        public string Admin3Name { get;set; }
        public override string ToString()
        {
            return Name;
        }
    }
}
