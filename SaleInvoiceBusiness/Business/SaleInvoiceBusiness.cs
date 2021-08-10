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
    public class SaleInvoiceBusiness : BaseBusiness<SaleInvoiceViewModel, SaleInvoiceRepository>, ISaleInvoiceBusiness
    {
        ISaleInvoiceRepository saleInvoiceRepository;
        ISaleInvoiceItemRepository saleInvoiceItemRepository;
        private IItemBusiness itemBusiness;
        private ISaleTypeBusiness sellTypeBusiness;
        private IStockItemBusiness stockItemBusiness;
        public SaleInvoiceBusiness(ISaleInvoiceRepository saleInvoiceRepository, ISaleInvoiceItemRepository saleInvoiceItemRepository,IItemBusiness itemBusiness, ISaleTypeBusiness sellTypeBusiness, IStockItemBusiness stockItemBusiness)
        {
            this.saleInvoiceRepository = saleInvoiceRepository;
            this.saleInvoiceItemRepository = saleInvoiceItemRepository;
            this.itemBusiness = itemBusiness;
            this.sellTypeBusiness = sellTypeBusiness;
            this.stockItemBusiness = stockItemBusiness;
        }
        public List<SaleInvoiceViewModel> GetSellInvoices()
        {
            return saleInvoiceRepository.GetSaleInvoices().Rows.Cast<DataRow>().Select(r => new SaleInvoiceViewModel() { SellInvoiceId = (int)r["SellInvoiceId"], SellTypeId = (int)r["SellTypeId"], CreatedDate = DateTime.Parse(r["CreatedDate"].ToString()), Customer = r["Customer"].ToString(), TimeStamp = (int)r["TimeStamp"], UserId = (int)r["UserId"],SellTypeTitle= r["SellTypeTitle"].ToString() }).ToList();
        }
        public bool AddSellInvoice(SaleInvoiceViewModel model)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                try
                {
                    model.SellInvoiceId = saleInvoiceRepository.GetLastSaleInvoiceId() + 1;
                    bool succsess = saleInvoiceRepository.AddSaleInvoice(model);
                    if (succsess)
                    {
                        foreach (SaleInvoiceItemDataRow item in model.ItemTable.Rows)
                        {
                            item["SellInvoiceId"] = model.SellInvoiceId;
                        }
                        if (saleInvoiceItemRepository.UpdateSaleInvoiceItems(model.ItemTable) == true)
                        {
                            bool StockUpdateSuccess = true;
                            foreach (SaleInvoiceItemDataRow row in model.ItemTable.Rows)
                            {
                                StockUpdateSuccess = stockItemBusiness.UpdateStockItem((int)row["StockRoomId"], (int)row["ItemId"], row["TracingFactor"].ToString(), -1 * (int)row["Quantity"]);
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
                            if (!stockItemBusiness.UpdateStockItem(item.StockRoomId, item.ItemId, item.TracingFactor, item.Quantity)) return false;
                        }
                        if (!saleInvoiceItemRepository.RemoveSaleInvoiceItems(int.Parse(invoiceId))) return false;
                        if (!saleInvoiceRepository.DeleteSaleInvoice(int.Parse(invoiceId))) return false;
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
