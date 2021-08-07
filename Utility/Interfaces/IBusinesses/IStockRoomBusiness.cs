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
        DataTable GetStockRoom(int id);
    }
}
