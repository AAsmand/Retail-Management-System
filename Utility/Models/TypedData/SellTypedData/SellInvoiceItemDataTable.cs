using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Project.Repositories.TypedData
{
    public class SaleInvoiceItemDataTable:DataTable
    {
        public SaleInvoiceItemDataTable()
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
            return typeof(SaleInvoiceItemDataRow);
        }

        protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
        {
            return new SaleInvoiceItemDataRow(builder);
        }
        public SaleInvoiceItemDataRow this[int idx]
        {
            get { return (SaleInvoiceItemDataRow)Rows[idx]; }
        }
        public void Add(SaleInvoiceItemDataRow row)
        {
            Rows.Add(row);
        }
        public void Remove(SaleInvoiceItemDataRow row)
        {
            Rows.Remove(row);
        }
        public new SaleInvoiceItemDataRow NewRow()
        {
            SaleInvoiceItemDataRow row = (SaleInvoiceItemDataRow)NewRow();
            return row;
        }
    }
}

