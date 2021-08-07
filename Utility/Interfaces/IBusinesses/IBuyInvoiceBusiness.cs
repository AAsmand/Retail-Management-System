using Project.Models;
using Project.Repositories;
using Project.Repositories.TypedData;
using Project.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;


namespace Project.Business
{
    public interface IBuyInvoiceBusiness : IConcurrencyChecker
    {

        List<BuyInvoiceViewModel> GetBuyInvoices();
        bool AddBuyInvoice(BuyInvoiceViewModel model);

        bool RemoveBuyInvoices(List<string> buyInvoicesId);
        ItemViewModel GetItem(int itemId);
        StockRoomViewModel GetStockRoom(int stockRoomId);
    }
}
