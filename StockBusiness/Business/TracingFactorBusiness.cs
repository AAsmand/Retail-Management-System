using Project.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Utility.Interfaces;

namespace Project.Business
{
    public class TracingFactorBusiness: ITracingFactorBusiness
    {
        ITracingFactorRepository tracingFactorRepository;
        public TracingFactorBusiness(ITracingFactorRepository tracingFactorRepository)
        {
            this.tracingFactorRepository = tracingFactorRepository;
        }
        public DataTable GetTracingFactors()
        {
            return tracingFactorRepository.GetData();
        }
    }
}
