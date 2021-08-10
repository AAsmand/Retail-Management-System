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
         DataTable GetBuyInvoices();
         bool DeleteBuyInvoice(int buyInvoiceId);
         bool AddBuyInvoice(BuyInvoiceViewModel model);
         int GetLastBuyInvoiceId();
    }
}
