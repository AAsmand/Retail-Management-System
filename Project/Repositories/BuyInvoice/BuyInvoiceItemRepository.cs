using Project.Models;
using Project.Repositories.TypedData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Project.Repositories
{
    public class BuyInvoiceItemRepository
    {
        public SqlConnection connection;
        public SqlCommand command;
        public SqlDataAdapter adapter;
        public DataSet ds;
        public SqlDataReader dr;

        public BuyInvoiceItemRepository()
        {
            if (connection == null) connection = new SqlConnection("data source=.\\sepidar;Initial Catalog=ProjectDB2;User Id=damavand;Password=damavand");
            if (command == null) command = new SqlCommand();
            if (adapter == null) adapter = new SqlDataAdapter();
            if (ds == null) ds = new DataSet();
        }
        public bool UpdateBuyInvoiceItem(DataTable table)
        {
            ds.Tables.Clear();
            ds.Tables.Add(table);
            adapter.InsertCommand = new SqlCommand("Insert into BuyInvoiceItem(ItemId,StockId,TracingFactor,Quantity,Fee,BuyInvoiceId,Offer,Extras,NetPrice) Values(@ItemId,@StockItemId,@TracingFactor,@Quantity,@Fee,@BuyInvoiceId,@Offer,@Extras,@NetPrice)");
            adapter.InsertCommand.Connection = connection;
            adapter.InsertCommand.Parameters.Add("@ItemId", SqlDbType.Int, 15, "ItemId");
            adapter.InsertCommand.Parameters.Add("@StockItemId", SqlDbType.Int, 15, "StockItemId");
            adapter.InsertCommand.Parameters.Add("@TracingFactor", SqlDbType.NVarChar, 15, "TracingFactor");
            adapter.InsertCommand.Parameters.Add("@Quantity", SqlDbType.Int, 15, "Quantity");
            adapter.InsertCommand.Parameters.Add("@Fee", SqlDbType.Int, 15, "Fee");
            adapter.InsertCommand.Parameters.Add("@BuyInvoiceId", SqlDbType.Int, 15, "BuyInvoiceId");
            adapter.InsertCommand.Parameters.Add("@Offer", SqlDbType.Int, 15, "Offer");
            adapter.InsertCommand.Parameters.Add("@Extras", SqlDbType.Int, 15, "Extras");
            adapter.InsertCommand.Parameters.Add("@NetPrice", SqlDbType.Int, 15, "NetPrice");
            connection.Open();
            if (adapter.Update(ds.Tables[0]) > 0)
            {
                connection.Close();
                return true;
            }
            else
            {
                connection.Close();
                return false;
            }
        }
        public bool RemoveBuyInvoiceItems(int buyInvoiceId)
        {
            command.Connection = connection;
            command.CommandText = "delete from BuyInvoiceItem where BuyInvoiceId=@Id";
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@Id", buyInvoiceId);
            connection.Open();
            try
            {
                if (command.ExecuteNonQuery() > 0)
                {
                    connection.Close();
                    return true;
                }
                return false;
            }
            finally
            {
                connection.Close();
            }

        }
        public List<BuyInvoiceItemModel> GetBuyInvoiceItems(int buyInvoiceId)
        {
            command.Connection = connection;
            command.CommandText = "select * from BuyInvoiceItem  where BuyInvoiceId=@BuyInvoiceId";
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@BuyInvoiceId", buyInvoiceId);
            connection.Open();
            adapter.SelectCommand = command;
            ds.Clear();
            adapter.Fill(ds, "Item");
            connection.Close();
            return ds.Tables["Item"].Rows.Cast<DataRow>().Select(r=>new BuyInvoiceItemModel() {BuyInvoiceItemId=(int)r["BuyInvoiceItemId"],BuyInvoiceId=(int)r["BuyInvoiceId"],Quantity= (int)r["Quantity"],StockItemId= (int)r["Quantity"] }).ToList();
        }
    }
}
