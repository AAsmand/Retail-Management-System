using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Utility.Interfaces
{
    public interface IBuyInvoiceItemRepository:IBaseRepository
    {
        bool UpdateBuyInvoiceItem(DataTable table);
        bool RemoveBuyInvoiceItems(int buyInvoiceId);
        DataTable GetBuyInvoiceItems(int buyInvoiceId);

    }
}

