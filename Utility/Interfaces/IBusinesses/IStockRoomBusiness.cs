using Project.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Project.Business
{
    public interface IStockRoomBusiness
    {
        DataTable GetStockRooms(int id);
        DataTable GetItemStockRooms(int SRId = 0, int itemId = 0);
    }
}
