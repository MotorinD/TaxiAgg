using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiAgg.Models
{
    internal class ResponseTaxiModel
    {
        public int Id { get; set; }

        public int ServiceId { get; set; }

        public DriverInfo Driver { get; set; }
        public MachineInfo Machine { get; set; }
        public decimal Price { get; set; }

        public TimeSpan ArrivalTime { get; set; }
        public TimeSpan ExtimateTravelTime { get; set; }

        public string Description { get; set; }
    }

    internal class DriverInfo
    {
        public string Name { get; set; }

        public double Rating { get; set; }
    }

    internal class MachineInfo
    {
        public string Model { get; set; }

        public string Color { get; set; }
    }
}
