using Project.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Utility.Interfaces
{
    public interface ISaleInvoiceItemRepository:IBaseRepository
    {
        bool UpdateSaleInvoiceItems(DataTable table);
        bool RemoveSaleInvoiceItems(int sellInvoiceId);
        List<SaleInvoiceItemModel> GetSaleInvoiceItems(int sellInvoiceId);
    }
}
