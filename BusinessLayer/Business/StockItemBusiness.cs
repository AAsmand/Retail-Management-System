using Project.Repositories;
using Project.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Project.Business
{
    public class StockItemBusiness: BaseBusiness<StockItemViewModel,StockItemRepository>, IStockItemBusiness
    {
        StockItemRepository stockItemRepository;
        public StockItemBusiness()
        {
            stockItemRepository = new StockItemRepository();
        }
        public DataTable GetDataForChoose(params object[] parameters)
        {
            return stockItemRepository.GetDataToChoose(parameters);
        }

        public StockItemViewModel GetStockItem(int stockItem)
        {
            return stockItemRepository.GetStockItem(stockItem);
        }
    }
}
