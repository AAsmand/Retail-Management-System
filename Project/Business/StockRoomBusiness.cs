using Project.Business.ChooseBusiness;
using Project.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Project.Business
{
    class StockRoomBusiness : IChooseBusiness
    {
        StockRoomRepository stockRoomRepository;
        public StockRoomBusiness()
        {
            stockRoomRepository = new StockRoomRepository();
        }
        public DataTable GetDataForChoose(params object[] parameters)
        {
            return stockRoomRepository.GetDataToChoose(parameters);
        }
    }
}
