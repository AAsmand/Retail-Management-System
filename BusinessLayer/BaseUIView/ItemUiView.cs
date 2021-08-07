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
    public class ItemUiView : IBaseUiView
    {
        private ItemRepository itemRepository;
        int _id;
        public ItemUiView(int id=0)
        {
            itemRepository = new ItemRepository();
            _id = id;
        }
        public List<DataGridViewColumn> GetColumn()
        {
            return new List<DataGridViewColumn>() {
                    new DataGridViewTextBoxColumn() { Name = "ItemId", HeaderText = "شماره کالا/خدمت", DataPropertyName = "ItemId" },
                    new DataGridViewTextBoxColumn() { Name = "Title", HeaderText = "عنوان", DataPropertyName = "Title" },
                    new DataGridViewCheckBoxColumn() { Name = "HasTracingFactor", HeaderText = "ردیابی", DataPropertyName = "HasTracingFactor" }
        }; 
        }

        public DataTable GetData()
        {
            return itemRepository.GetDataToChoose(_id);
        }
    }
}
