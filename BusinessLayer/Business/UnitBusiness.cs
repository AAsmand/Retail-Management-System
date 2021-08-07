using Project.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Project.Business
{
    public class UnitBusiness:IUnitBusiness
    {
        UnitRepository unitRepository;

        public UnitBusiness()
        {
            unitRepository = new UnitRepository();
           
        }
        public DataTable GetUnits()
        {
            return unitRepository.GetData();
        }
    }
}
