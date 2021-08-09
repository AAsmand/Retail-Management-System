using Project.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Utility.Interfaces;

namespace Project.Business
{
    public class UnitBusiness:IUnitBusiness
    {
        IUnitRepository unitRepository;

        public UnitBusiness(IUnitRepository unitRepository)
        {
            this.unitRepository = unitRepository;


        }
        public DataTable GetUnits()
        {
            return unitRepository.GetData();
        }
    }
}
