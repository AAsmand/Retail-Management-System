using Project.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Utility.Interfaces
{
    public interface IStockItemRepository
    {
        DataTable GetStockItem(int itemId, int stockRoomId, string tracingFactor);
        StockItemViewModel GetStockItem(int stockItemId);
        bool UpdateStockItem(int stockItemId, int ChangeValue);
        bool UpdateStockItem(int stockRoomId, int itemId, string tracingFactor, int ChangeValue);
        DataTable GetStockItems(int itemId, int stockRoomId, string tracingFactor = "");
        DataTable GetStockRoomsForItem(int itemId, int stockRoomId);
        int AddStockItem(StockItemViewModel model);
    }
}
