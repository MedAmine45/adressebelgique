using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.Models
{
    public class Rue
    {
        public int[] cps { get; set; }
        public string nom { get; set; }
        public string commune { get; set; }
        public double xMin { get; set; }
        public double xMax { get; set; }
        public double yMin { get; set; }
        public double yMax { get; set; }

    }

    public class Rues
    {
        public Rue[] rues { get; set; } 
    }
}
