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
        public DataTable GetStockRooms(int id)
        {
            return stockRoomRepository.GetStockRoomByFilter(id);
        }
        public DataTable GetItemStockRooms(int SRId=0,int itemId=0)
        {
            return stockRoomRepository.GetItemStockRoomByFilter(SRId, itemId);
        }
    }
}
