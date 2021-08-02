using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Project.Repositories.TypedData
{
    public class SellInvoiceItemDataTable:DataTable
    {
        public SellInvoiceItemDataTable()
        {
            Columns.Add(new DataColumn("SellInvoiceItemId", typeof(int)));
            Columns.Add(new DataColumn("SellInvoiceId", typeof(int)));
            Columns.Add(new DataColumn("ItemId", typeof(int)));
            Columns.Add(new DataColumn("ItemTitle", typeof(string)));
            Columns.Add(new DataColumn("StockRoomId", typeof(int)));
            Columns.Add(new DataColumn("TracingFactor", typeof(string)));
            Columns.Add(new DataColumn("Quantity", typeof(int)));
            Columns.Add(new DataColumn("Fee", typeof(int)));
            Columns.Add(new DataColumn("Total", typeof(int)));
            Columns.Add(new DataColumn("Offer", typeof(int)));
            Columns.Add(new DataColumn("Extras", typeof(int)));
            Columns.Add(new DataColumn("NetPrice", typeof(int)));
            Columns.Add(new DataColumn("StockValue", typeof(int)));
            Columns.Add(new DataColumn("HasTracingFactor", typeof(int)));
        }
        protected override Type GetRowType()
        {
            return typeof(SellInvoiceItemDataRow);
        }

        protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
        {
            return new SellInvoiceItemDataRow(builder);
        }
        public SellInvoiceItemDataRow this[int idx]
        {
            get { return (SellInvoiceItemDataRow)Rows[idx]; }
        }
        public void Add(SellInvoiceItemDataRow row)
        {
            Rows.Add(row);
        }
        public void Remove(SellInvoiceItemDataRow row)
        {
            Rows.Remove(row);
        }
        public new SellInvoiceItemDataRow NewRow()
        {
            SellInvoiceItemDataRow row = (SellInvoiceItemDataRow)NewRow();
            return row;
        }
    }
}

