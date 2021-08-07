using Project.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Utility.Interfaces
{
    public interface ISaleInvoiceRepository:IBaseRepository
    {
        DataTable GetData();
        bool DeleteItem(int itemId);
        bool AddItem(SaleInvoiceViewModel model);
        int GetLastId();
    }
}
