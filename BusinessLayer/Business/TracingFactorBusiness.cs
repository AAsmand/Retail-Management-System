using Project.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Project.Business
{
    public class TracingFactorBusiness: ITracingFactorBusiness
    {
        TracingFactorRepository tracingFactorRepository;
        public TracingFactorBusiness()
        {
            tracingFactorRepository = new TracingFactorRepository();
        }
        public DataTable GetTracingFactors()
        {
            return tracingFactorRepository.GetData();
        }
    }
}
