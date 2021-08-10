using Project.Repositories;
using Project.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Utility.Interfaces;

namespace Project.Business
{
    public class StockItemBusiness: BaseBusiness<StockItemViewModel,StockItemRepository>, IStockItemBusiness
    {
        IStockItemRepository stockItemRepository;
        public StockItemBusiness(IStockItemRepository stockItemRepository)
        {
            this.stockItemRepository = stockItemRepository;
        }

        public int AddStockItem(StockItemViewModel model)
        {
            return stockItemRepository.AddStockItem(model);
        }

        public DataTable GetData(int itemId=0,int SRId=0,string tracingFactor="")
        {
            return stockItemRepository.GetStockItemsByFilter(itemId,SRId,tracingFactor);
        }

        public StockItemViewModel GetStockItem(int stockItem)
        {
            return stockItemRepository.GetStockItem(stockItem);
        }
        public bool UpdateStockItem(int stockRoomId,int itemId,string tracingFactor,int value)
        {
            return stockItemRepository.UpdateStockItem(stockRoomId, itemId, tracingFactor, value);
        }
        public bool UpdateStockItem(int stockItemId, int value)
        {
            return stockItemRepository.UpdateStockItem(stockItemId, value);
        }
    }
}
