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
        DataTable GetSaleInvoices();
        bool DeleteSaleInvoice(int itemId);
        bool AddSaleInvoice(SaleInvoiceViewModel model);
        int GetLastSaleInvoiceId();
    }
}
