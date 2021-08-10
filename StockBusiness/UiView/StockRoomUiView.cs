using Project.Business;
using Project.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utility.Interfaces;

namespace BusinessLayer.Business.BaseUIView
{
    public class StockRoomUiView : IBaseUiView
    {
        private IStockRoomBusiness stockRoomBusiness;
        int _SRId, _itemId;
        public StockRoomUiView(IStockRoomBusiness stockRoomBusiness,int stockRoomId=0,int itemId=0)
        {
            this.stockRoomBusiness = stockRoomBusiness;
            _SRId = stockRoomId;
            _itemId = itemId;
        }
        public List<DataGridViewColumn> GetColumn()
        {
            return new List<DataGridViewColumn>(){ new DataGridViewTextBoxColumn() { Name = "SRId", HeaderText = "شماره انبار", DataPropertyName = "SRId" },
                    new DataGridViewTextBoxColumn() { Name = "Title", HeaderText = "عنوان", DataPropertyName = "Title" },
                    new DataGridViewTextBoxColumn() { Name = "Address", HeaderText = "آدرس", DataPropertyName = "Address" } };
        }

        public DataTable GetData()
        {
            return _itemId == 0 ? stockRoomBusiness.GetStockRooms(_SRId) : stockRoomBusiness.GetItemStockRooms(_SRId, _itemId);
        }
    }
}
