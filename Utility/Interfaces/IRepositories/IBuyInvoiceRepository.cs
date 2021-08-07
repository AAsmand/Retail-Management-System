using Project.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Utility.Interfaces
{
    public interface IBuyInvoiceRepository:IBaseRepository
    {
         DataTable GetData();
         bool DeleteItem(int buyInvoiceId);
         bool AddItem(BuyInvoiceViewModel model);
         int GetLastId();
    }
}
