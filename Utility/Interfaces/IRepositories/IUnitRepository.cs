using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Utility.Interfaces
{
    public interface IUnitRepository:IBaseRepository
    {
        DataTable GetUnits();
    }
}
