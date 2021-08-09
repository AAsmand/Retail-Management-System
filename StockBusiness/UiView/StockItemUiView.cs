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
    public class StockItemUiView : IBaseUiView
    {
        private IStockItemBusiness stockItemBusiness;
        int _itemId,_stockRoomId;
        public StockItemUiView(IStockItemBusiness stockItemBusiness,int itemId =0,int stockRoomId=0)
        {
            this.stockItemBusiness = stockItemBusiness;
            _itemId = itemId;
            _stockRoomId = stockRoomId;
        }
        public List<DataGridViewColumn> GetColumn()
        {
            return new List<DataGridViewColumn>() {
                    new DataGridViewTextBoxColumn() { Name = "StockItemId", HeaderText = "شماره یکتا", DataPropertyName = "StockItemId" },
                    new DataGridViewTextBoxColumn() { Name = "SRId", HeaderText = "شماره انبار", DataPropertyName = "SRId" },
                    new DataGridViewTextBoxColumn() { Name = "Title", HeaderText = "عنوان", DataPropertyName = "Title" },
                    new DataGridViewTextBoxColumn() { Name = "StockValue", HeaderText = "موجودی", DataPropertyName = "StockValue" },
                    new DataGridViewTextBoxColumn() { Name = "TracingFactor", HeaderText = "عامل ردیابی", DataPropertyName = "TracingFactor" }};
        }

        public DataTable GetData()
        {
            return stockItemBusiness.GetData(_itemId, _stockRoomId);
        }
    }
}
