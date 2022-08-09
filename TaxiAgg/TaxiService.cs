using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaxiAgg.Interfaces;
using TaxiAgg.Services;
using TaxiAgg.Models;
using System.Linq;

namespace TaxiAgg
{
    internal class TaxiService
    {
        private List<ITaxiRequestable> TaxiCompanyList;
        public TaxiService()
        {
            this.TaxiCompanyList = new List<ITaxiRequestable>();
            this.Init();
        }

        private void Init()
        {
            this.TaxiCompanyList.AddRange(
                new List<ITaxiRequestable>
                {
                    new TaxiCompanyService(),
                    new TaxiCompanyService2(),
                    new TaxiCompanyService3()
                });
        }

        public async Task<ResponseTaxiModel> RequestTaxiAsync(RequestTaxiParams args)
        {
            var tasks = new List<Task<ResponseTaxiModel>>();

            foreach (var company in this.TaxiCompanyList)
                tasks.Add(Task.Run(() => this.RequestTaxi(company, args)));

            while (tasks.Count > 0)
            {
                var finishedTask = await Task.WhenAny(tasks);

                if (finishedTask.Result != null && finishedTask.Status == TaskStatus.RanToCompletion)
                    return finishedTask.Result;

                tasks.Remove(finishedTask);
            }

            return null;
        }

        private ResponseTaxiModel RequestTaxi(ITaxiRequestable taxiService, RequestTaxiParams args)
        {
            try
            {
                return taxiService.Request(args);
            }
            catch (Exception e)
            {
                //logging
                return null;
            }
        }

        public bool BookTaxi(int requestId, int serviceId)
        {
            var service = this.TaxiCompanyList.FirstOrDefault(o => o.ServiceId == serviceId);

            if (service is null)
                return false;

            return service.Book(requestId);
        }
    }
}
