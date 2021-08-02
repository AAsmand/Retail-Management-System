using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Project.Repositories.TypedData
{
    public class BuyInvoiceTable:DataTable
    {
        public BuyInvoiceTable()
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
            return typeof(BuyInvoiceRow);
        }

        protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
        {
            return new BuyInvoiceRow(builder);
        }
        public BuyInvoiceRow this[int idx]
        {
            get { return (BuyInvoiceRow)Rows[idx]; }
        }
        public void Add(BuyInvoiceRow row)
        {
            Rows.Add(row);
        }
        public void Remove(BuyInvoiceRow row)
        {
            Rows.Remove(row);
        }
        public new BuyInvoiceRow NewRow()
        {
            BuyInvoiceRow row = (BuyInvoiceRow)NewRow();
            return row;
        }
    }
}

