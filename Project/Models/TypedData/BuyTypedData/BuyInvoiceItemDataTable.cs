using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Project.Repositories.TypedData
{
    public class BuyInvoiceItemDataTable:DataTable
    {
        public BuyInvoiceItemDataTable()
        {
            Columns.Add(new DataColumn("BuyInvoiceItemId", typeof(int)));
            Columns.Add(new DataColumn("BuyInvoiceId", typeof(int)));
            Columns.Add(new DataColumn("ItemId", typeof(int)));
            Columns.Add(new DataColumn("ItemTitle", typeof(string)));
            Columns.Add(new DataColumn("StockItemId", typeof(int)));
            Columns.Add(new DataColumn("TracingFactor", typeof(string)));
            Columns.Add(new DataColumn("Quantity", typeof(int)));
            Columns.Add(new DataColumn("Fee", typeof(int)));
            Columns.Add(new DataColumn("Total", typeof(int)));
            Columns.Add(new DataColumn("Offer", typeof(int)));
            Columns.Add(new DataColumn("Extras", typeof(int)));
            Columns.Add(new DataColumn("NetPrice", typeof(int)));
        }
        protected override Type GetRowType()
        {
            return typeof(BuyInvoiceItemDataRow);
        }

        protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
        {
            return new BuyInvoiceItemDataRow(builder);
        }
        public BuyInvoiceItemDataRow this[int idx]
        {
            get { return (BuyInvoiceItemDataRow)Rows[idx]; }
        }
        public void Add(BuyInvoiceItemDataRow row)
        {
            Rows.Add(row);
        }
        public void Remove(BuyInvoiceItemDataRow row)
        {
            Rows.Remove(row);
        }
        public new BuyInvoiceItemDataRow NewRow()
        {
            BuyInvoiceItemDataRow row = (BuyInvoiceItemDataRow)NewRow();
            return row;
        }
    }
}

