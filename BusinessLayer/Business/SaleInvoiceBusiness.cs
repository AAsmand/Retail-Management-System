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
using Utility.Interfaces;

namespace Project.Business
{
    public class SaleInvoiceBusiness : BaseBusiness<BuyInvoiceViewModel, BuyInvoiceRepository>, ISaleInvoiceBusiness
    {
        ISaleInvoiceRepository saleInvoiceRepository;
        ISaleInvoiceItemRepository saleInvoiceItemRepository;
        StockItemRepository stockItemRepository;
        private ItemBusiness itemBusiness;
        private SaleTypeBusiness sellTypeBusiness;
        private StockItemBusiness stockItemBusiness;
        public SaleInvoiceBusiness(/*ISaleInvoiceRepository saleInvoiceRepository, ISaleInvoiceItemRepository saleInvoiceItemRepository*/)
        {
            this.saleInvoiceRepository = new SaleInvoiceRepository();
            this.saleInvoiceItemRepository = new SaleInvoiceItemRepository() ;
            stockItemRepository = new StockItemRepository();
            itemBusiness = new ItemBusiness();
            sellTypeBusiness = new SaleTypeBusiness(new SaleTypeRepository());
            stockItemBusiness = new StockItemBusiness();
        }
        public List<SaleInvoiceViewModel> GetSellInvoices()
        {
            return saleInvoiceRepository.GetData().Rows.Cast<DataRow>().Select(r => new SaleInvoiceViewModel() { SellInvoiceId = (int)r["SellInvoiceId"], SellTypeId = (int)r["SellTypeId"], CreatedDate = DateTime.Parse(r["CreatedDate"].ToString()), Customer = r["Customer"].ToString(), TimeStamp = (int)r["TimeStamp"], UserId = (int)r["UserId"],SellTypeTitle= r["SellTypeTitle"].ToString() }).ToList();
        }
        public bool AddSellInvoice(SaleInvoiceViewModel model)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                try
                {
                    model.SellInvoiceId = saleInvoiceRepository.GetLastId() + 1;
                    bool succsess = saleInvoiceRepository.AddItem(model);
                    if (succsess)
                    {
                        foreach (SaleInvoiceItemDataRow item in model.ItemTable.Rows)
                        {
                            item["SellInvoiceId"] = model.SellInvoiceId;
                        }
                        if (saleInvoiceItemRepository.UpdateSaleInvoiceItem(model.ItemTable) == true)
                        {
                            bool StockUpdateSuccess = true;
                            foreach (SaleInvoiceItemDataRow row in model.ItemTable.Rows)
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
                        List<SaleInvoiceItemModel> listItem = saleInvoiceItemRepository.GetSaleInvoiceItems(int.Parse(invoiceId));
                        foreach (SaleInvoiceItemModel item in listItem)
                        {
                            if (!stockItemRepository.UpdateStockItem(item.StockRoomId, item.ItemId, item.TracingFactor, item.Quantity)) return false;
                        }
                        if (!saleInvoiceItemRepository.RemoveSaleInvoiceItems(int.Parse(invoiceId))) return false;
                        if (!saleInvoiceRepository.DeleteItem(int.Parse(invoiceId))) return false;
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
        public SaleTypeViewModel GetSellType(int sellTypeId)
        {
            return sellTypeBusiness.GetSellType(sellTypeId);
        }
        public StockItemViewModel GetStockItem(int stockItemId)
        {
            return stockItemBusiness.GetStockItem(stockItemId);
        }
    }
}
