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
    public class BuyInvoiceBusiness : BaseBusiness<BuyInvoiceViewModel, BuyInvoiceRepository>, IBuyInvoiceBusiness
    {
        public IBuyInvoiceRepository buyInvoiceRepository;
        IBuyInvoiceItemRepository buyInvoiceItemRepository;
        IStockItemBusiness stockItemBusiness;
        private IItemBusiness itemBusiness;
        private IStockRoomBusiness stockRoomBusiness;
        public BuyInvoiceBusiness(IBuyInvoiceRepository buyInvoiceRepository, IBuyInvoiceItemRepository buyInvoiceItemRepository, IStockItemBusiness stockItemBusiness, IItemBusiness itemBusiness, IStockRoomBusiness stockRoomBusiness)
        {
            this.buyInvoiceRepository = buyInvoiceRepository;
            this.buyInvoiceItemRepository = buyInvoiceItemRepository;
            this.stockItemBusiness = stockItemBusiness;
            this.itemBusiness = itemBusiness;
            this.stockRoomBusiness = stockRoomBusiness;
        }
        public List<BuyInvoiceViewModel> GetBuyInvoices()
        {
            return buyInvoiceRepository.GetBuyInvoices().Rows.Cast<DataRow>().Select(r => new BuyInvoiceViewModel() { BuyInvoiceId = r["BuyInvoiceId"].ToString(), SRId = r["SRId"].ToString(), CreatedDate = DateTime.Parse(r["CreatedDate"].ToString()), Supplier = r["Supplier"].ToString(), TimeStamp = (int)r["TimeStamp"], UserId = r["UserId"].ToString() }).ToList();
        }
        public bool AddBuyInvoice(BuyInvoiceViewModel model)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                try
                {
                    model.BuyInvoiceId = (buyInvoiceRepository.GetLastBuyInvoiceId() + 1).ToString();
                    bool succsess = buyInvoiceRepository.AddBuyInvoice(model);
                    if (succsess)
                    {
                        foreach (BuyInvoiceItemDataRow item in model.ItemList.Rows)
                        {
                            item.BuyInvoiceId = int.Parse(model.BuyInvoiceId);
                            DataTable table = stockItemBusiness.GetData(item.ItemId, int.Parse(model.SRId), item.TracingFactor.ToString());
                            if (table.Rows.Count == 0)
                            {
                                StockItemViewModel stockModel = new StockItemViewModel()
                                {
                                    ItemId = item.ItemId,
                                    SRId = int.Parse(model.SRId),
                                    StockValue = 0,
                                    CreatedDate = model.CreatedDate,
                                    TracingFactor = item.TracingFactor
                                };
                                item.StockItemId = stockItemBusiness.AddStockItem(stockModel);
                            }
                            else if (table.Rows.Count == 1)
                            {
                                item.StockItemId = int.Parse(table.Rows[0]["StockItemId"].ToString());
                            }
                        }
                        if (buyInvoiceItemRepository.UpdateBuyInvoiceItems(model.ItemList) == true)
                        {
                            foreach (BuyInvoiceItemDataRow item in model.ItemList.Rows)
                            {
                                stockItemBusiness.UpdateStockItem(item.StockItemId, item.Quantity);
                            }
                            transaction.Complete();
                            return true;
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
        
        public bool RemoveBuyInvoices(List<string> buyInvoicesId)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    foreach (string id in buyInvoicesId)
                    {
                        List<BuyInvoiceItemModel> listItem = buyInvoiceItemRepository.GetBuyInvoiceItems(int.Parse(id)).Rows.Cast<DataRow>().Select(r => new BuyInvoiceItemModel() { BuyInvoiceItemId = (int)r["BuyInvoiceItemId"], BuyInvoiceId = (int)r["BuyInvoiceId"], Quantity = (int)r["Quantity"], StockItemId = (int)r["StockId"] }).ToList();
                        foreach (BuyInvoiceItemModel item in listItem)
                        {
                            if (!stockItemBusiness.UpdateStockItem(item.StockItemId, item.Quantity * -1)) return false;
                        }
                        if (!buyInvoiceItemRepository.RemoveBuyInvoiceItems(int.Parse(id))) return false;
                        if (!buyInvoiceRepository.DeleteBuyInvoice(int.Parse(id))) return false;
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
        public StockRoomViewModel GetStockRoom(int stockRoomId)
        {
            return stockRoomBusiness.GetStockRooms(stockRoomId).Rows.Cast<DataRow>().Select(r => new StockRoomViewModel() { SRId = (int)r["SRId"], Title = r["Title"].ToString(), Address = r["Address"].ToString() }).FirstOrDefault();
        }
    }
}
