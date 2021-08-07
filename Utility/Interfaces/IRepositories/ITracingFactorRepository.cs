using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Utility.Interfaces
{
    public interface ITracingFactorRepository:IBaseRepository
    {
        DataTable GetData();
    }
}
