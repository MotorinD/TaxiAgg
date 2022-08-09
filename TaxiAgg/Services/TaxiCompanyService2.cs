using System;
using System.Threading;
using System.Threading.Tasks;
using TaxiAgg.Interfaces;
using TaxiAgg.Models;

namespace TaxiAgg.Services
{
    internal class TaxiCompanyService2 : ITaxiRequestable
    {
        public int ServiceId => 2;

        public bool Book(int Id)
        {
            return true;
        }

        public ResponseTaxiModel Request(RequestTaxiParams args)
        {
            var time = Program.GetRandomSleepTime();
            Console.WriteLine($"TaxiCompanyService2 will work:{time}ms"); //show estimate work time for testing
            Thread.Sleep(time);

            //throw new Exception(); //for test
            return new ResponseTaxiModel() { Description = "Taxi from TaxiCompanyService2", ServiceId = this.ServiceId };
        }

        public bool UnBook(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
