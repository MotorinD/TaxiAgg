using System;
using System.Threading;
using System.Threading.Tasks;
using TaxiAgg.Interfaces;
using TaxiAgg.Models;

namespace TaxiAgg.Services
{
    internal class TaxiCompanyService : ITaxiRequestable
    {
        public int ServiceId => 1;

        public bool Book(int Id)
        {
            return true;
        }

        public ResponseTaxiModel Request(RequestTaxiParams args)
        {
            var time = Program.GetRandomSleepTime();
            Console.WriteLine($"TaxiCompanyService will work:{time}ms"); //show estimate work time for testing
            Thread.Sleep(time);

            //throw new Exception(); //for test
            return new ResponseTaxiModel() { Description = "Taxi from TaxiCompanyService", ServiceId = this.ServiceId };
        }

        public bool UnBook(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
