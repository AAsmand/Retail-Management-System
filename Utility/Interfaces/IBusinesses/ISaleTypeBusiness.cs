using Project.Repositories;
using Project.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Utility.Interfaces;

namespace Project.Business
{
    public interface ISaleTypeBusiness
    {
        SaleTypeViewModel GetSellType(int sellTypeId);
    }
}
