using Project.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Project.Business
{
    public class StockRoomBusiness: IStockRoomBusiness
    {
        StockRoomRepository stockRoomRepository;
        public StockRoomBusiness()
        {
            stockRoomRepository = new StockRoomRepository();
        }
        public DataTable GetStockRoom(int id)
        {
            return stockRoomRepository.GetData(id);
        }
    }
}
