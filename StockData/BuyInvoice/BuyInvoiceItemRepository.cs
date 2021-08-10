using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Utility.Interfaces;

namespace Project.Repositories
{
    public class BuyInvoiceItemRepository:BaseRepository,IBuyInvoiceItemRepository
    {
        public bool UpdateBuyInvoiceItems(DataTable table)
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
        public DataTable GetBuyInvoiceItems(int buyInvoiceId)
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
            return ds.Tables["Item"];
        }
    }
}
