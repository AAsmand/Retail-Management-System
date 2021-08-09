using Project.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Utility.Interfaces;

namespace Project.Business
{
    public class StockRoomBusiness: IStockRoomBusiness
    {
        IStockRoomRepository stockRoomRepository;
        public StockRoomBusiness(IStockRoomRepository stockRoomRepository)
        {
            this.stockRoomRepository = stockRoomRepository;
        }
        public DataTable GetStockRoom(int id)
        {
            return stockRoomRepository.GetData(id);
        }
        public DataTable GetStockRooms(int SRId=0,int itemId=0)
        {
            return stockRoomRepository.GetData(SRId, itemId);
        }
    }
}
