using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiAgg.Models
{
    internal class RequestTaxiParams
    {
        public Adress Source { get; set; }
        public Adress Destination { get; set; }

        public string Description { get; set; }
    }

    internal class Adress
    {
        public string City { get; set; }

        public string Street { get; set; }

        public int BuildNum { get; set; }

        public int EntranceNum { get; set; }
    }
}
