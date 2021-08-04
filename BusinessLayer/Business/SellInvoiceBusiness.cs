using Project.Models;
using Project.Repositories;
using Project.Repositories.TypedData;
using Project.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Transactions;

namespace Project.Business
{
    public class SellInvoiceBusiness : BaseBusiness<BuyInvoiceViewModel, BuyInvoiceRepository>
    {
        public SellInvoiceRepository sellInvoiceRepository;
        SellInvoiceItemRepository sellInvoiceItemRepository;
        StockItemRepository stockItemRepository;
        private ItemBusiness itemBusiness;
        private SellTypeBusiness sellTypeBusiness;
        private StockItemBusiness stockItemBusiness;
        public SellInvoiceBusiness()
        {
            sellInvoiceRepository = new SellInvoiceRepository();
            sellInvoiceItemRepository = new SellInvoiceItemRepository();
            stockItemRepository = new StockItemRepository();
            itemBusiness = new ItemBusiness();
            sellTypeBusiness = new SellTypeBusiness();
            stockItemBusiness = new StockItemBusiness();
        }
        public List<SellInvoiceViewModel> GetSellInvoices()
        {
            return sellInvoiceRepository.GetData().Rows.Cast<DataRow>().Select(r => new SellInvoiceViewModel() { SellInvoiceId = (int)r["SellInvoiceId"], SellTypeId = (int)r["SellTypeId"], CreatedDate = DateTime.Parse(r["CreatedDate"].ToString()), Customer = r["Customer"].ToString(), TimeStamp = (int)r["TimeStamp"], UserId = (int)r["UserId"],SellTypeTitle= r["SellTypeTitle"].ToString() }).ToList();
        }
        public bool AddSellInvoice(SellInvoiceViewModel model)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                try
                {
                    model.SellInvoiceId = sellInvoiceRepository.GetLastId() + 1;
                    bool succsess = sellInvoiceRepository.AddItem(model);
                    if (succsess)
                    {
                        foreach (SellInvoiceItemDataRow item in model.ItemTable.Rows)
                        {
                            item["SellInvoiceId"] = model.SellInvoiceId;
                        }
                        if (sellInvoiceItemRepository.UpdateSellInvoiceItem(model.ItemTable) == true)
                        {
                            bool StockUpdateSuccess = true;
                            foreach (SellInvoiceItemDataRow row in model.ItemTable.Rows)
                            {
                                StockUpdateSuccess = stockItemRepository.UpdateStockItem((int)row["StockRoomId"], (int)row["ItemId"], row["TracingFactor"].ToString(), -1 * (int)row["Quantity"]);
                                if (!StockUpdateSuccess)
                                {
                                    return false;
                                }
                            }
                            if (StockUpdateSuccess)
                            {
                                transaction.Complete();
                                return true;
                            }
                        }
                    }
                }
                catch (Exception exp)
                {
                    return false;
                }
            }
            return false;
        }

        public bool RemoveSellInvoices(List<string> sellInvoicesId)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    foreach (string invoiceId in sellInvoicesId)
                    {
                        List<SellInvoiceItemModel> listItem = sellInvoiceItemRepository.GetSellInvoiceItems(int.Parse(invoiceId));
                        foreach (SellInvoiceItemModel item in listItem)
                        {
                            if (!stockItemRepository.UpdateStockItem(item.StockRoomId, item.ItemId, item.TracingFactor, item.Quantity)) return false;
                        }
                        if (!sellInvoiceItemRepository.RemoveBuyInvoiceItems(int.Parse(invoiceId))) return false;
                        if (!sellInvoiceRepository.DeleteItem(int.Parse(invoiceId))) return false;
                    }
                    scope.Complete();
                    return true;
                }
            }
            catch (Exception exp) { return false; }
        }

        public ItemViewModel GetItem(int itemId)
        {
            return itemBusiness.GetItem(itemId);
        }
        public SellTypeViewModel GetSellType(int sellTypeId)
        {
            return sellTypeBusiness.GetSellType(sellTypeId);
        }
        public StockItemViewModel GetStockItem(int stockItemId)
        {
            return stockItemBusiness.GetStockItem(stockItemId);
        }
    }
}
