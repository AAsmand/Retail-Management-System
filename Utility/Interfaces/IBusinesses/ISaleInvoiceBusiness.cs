using Project.Models;
using Project.Repositories;
using Project.Repositories.TypedData;
using Project.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Utility.Interfaces;

namespace Project.Business
{
    public interface ISaleInvoiceBusiness :IConcurrencyChecker
    {

        List<SaleInvoiceViewModel> GetSellInvoices();
        bool AddSellInvoice(SaleInvoiceViewModel model);

        bool RemoveSellInvoices(List<string> sellInvoicesId);

        ItemViewModel GetItem(int itemId);
        SaleTypeViewModel GetSellType(int sellTypeId);
        StockItemViewModel GetStockItem(int stockItemId);
    }
}
