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
    public class SaleTypeUiView : IBaseUiView
    {
        private SaleTypeRepository saleTypeRepository;
        int _saleTypeId;
        public SaleTypeUiView(int saleTypeId=0)
        {
            saleTypeRepository = new SaleTypeRepository();
            _saleTypeId = saleTypeId;
        }
        public List<DataGridViewColumn> GetColumn()
        {
            return new List<DataGridViewColumn>()
            {
                 new DataGridViewTextBoxColumn() { Name = "SellTypeId", HeaderText = "شماره نوع فروش", DataPropertyName = "SellTypeId" },
                    new DataGridViewTextBoxColumn() { Name = "SellTypeTitle", HeaderText = "عنوان", DataPropertyName = "SellTypeTitle" }
            };
        }

        public DataTable GetData()
        {
            return saleTypeRepository.GetDataToChoose(_saleTypeId);
        }
    }
}
