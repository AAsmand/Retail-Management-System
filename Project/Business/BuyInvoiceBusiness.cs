﻿using Project.Models;
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
    public class BuyInvoiceBusiness : BaseBusiness<BuyInvoiceViewModel, BuyInvoiceRepository>
    {
        public BuyInvoiceRepository buyInvoiceRepository;
        BuyInvoiceItemRepository buyInvoiceItemRepository;
        StockItemRepository stockItemRepository;
        private ItemRepository itemRepository;
        public BuyInvoiceBusiness()
        {
            buyInvoiceRepository = new BuyInvoiceRepository();
            buyInvoiceItemRepository = new BuyInvoiceItemRepository();
            stockItemRepository = new StockItemRepository();
            itemRepository = new ItemRepository();
        }
        public List<BuyInvoiceViewModel> GetBuyInvoices()
        {
            return buyInvoiceRepository.GetData().Rows.Cast<DataRow>().Select(r => new BuyInvoiceViewModel() { BuyInvoiceId = r["BuyInvoiceId"].ToString(), SRId = r["SRId"].ToString(), CreatedDate = DateTime.Parse(r["CreatedDate"].ToString()), Supplier = r["Supplier"].ToString(), TimeStamp = (int)r["TimeStamp"], UserId = r["UserId"].ToString() }).ToList();
        }
        public bool AddBuyInvoice(BuyInvoiceViewModel model)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                try
                {
                    model.BuyInvoiceId = (buyInvoiceRepository.GetLastId() + 1).ToString();
                    bool succsess = buyInvoiceRepository.AddItem(model);
                    if (succsess)
                    {
                        foreach (BuyInvoiceItemDataRow item in model.ItemList.Rows)
                        {
                            item.BuyInvoiceId = int.Parse(model.BuyInvoiceId);
                            DataTable table = stockItemRepository.GetStockItem(item.ItemId, int.Parse(model.SRId), item.TracingFactor.ToString());
                            if (table.Rows.Count == 0)
                            {
                                StockItemModel stockModel = new StockItemModel()
                                {
                                    ItemId = item.ItemId,
                                    SRId = int.Parse(model.SRId),
                                    StockValue = 0,
                                    CreatedDate = model.CreatedDate,
                                    TracingFactor = item.TracingFactor
                                };
                                item.StockItemId = stockItemRepository.AddStockItem(stockModel);
                            }
                            else if (table.Rows.Count == 1)
                            {
                                item.StockItemId = int.Parse(table.Rows[0]["StockItemId"].ToString());
                            }
                        }
                        if (buyInvoiceItemRepository.UpdateBuyInvoiceItem(model.ItemList) == true)
                        {
                            foreach (BuyInvoiceItemDataRow item in model.ItemList.Rows)
                            {
                                stockItemRepository.UpdateStockItem(item.StockItemId, item.Quantity);
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
                        List<BuyInvoiceItemModel> listItem = buyInvoiceItemRepository.GetBuyInvoiceItems(int.Parse(id));
                        foreach (BuyInvoiceItemModel item in listItem)
                        {
                            if (!stockItemRepository.UpdateStockItem(item.StockItemId, item.Quantity * -1)) return false;
                        }
                        if (!buyInvoiceItemRepository.RemoveBuyInvoiceItems(int.Parse(id))) return false;
                        if (!buyInvoiceRepository.DeleteItem(int.Parse(id))) return false;
                    }
                    scope.Complete();
                    return true;
                }
            }
            catch (Exception exp) { return false; }
        }
    }
}