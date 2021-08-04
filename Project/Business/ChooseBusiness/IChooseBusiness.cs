using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Project.Business.ChooseBusiness
{
    public interface IChooseBusiness
    {
        DataTable GetDataForChoose(params object[] parameters);
    }
}
