using Project.Repositories;
using Project.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Project.Business
{
    public interface IStockItemBusiness:IConcurrencyChecker
    {
        DataTable GetData(int itemId = 0, int SRId = 0, string tracingFactor = "");
        StockItemViewModel GetStockItem(int stockItem);
        int AddStockItem(StockItemViewModel model);
        bool UpdateStockItem(int stockRoomId, int itemId, string tracingFactor, int value);
        bool UpdateStockItem(int stockItemId, int value);
    }
}
