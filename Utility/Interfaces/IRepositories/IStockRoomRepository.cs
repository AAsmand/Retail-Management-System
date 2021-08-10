using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Utility.Interfaces
{
    public interface IStockRoomRepository
    {
        DataTable GetItemStockRoomByFilter(int srId = 0, int itemId = 0);
        DataTable GetStockRoomByFilter(int stockRoomId = 0);
    }
}
