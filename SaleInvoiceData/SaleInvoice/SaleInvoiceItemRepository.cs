using Project.Models;
using Project.Repositories.TypedData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Utility.Interfaces;

namespace Project.Repositories
{
    public class SaleInvoiceItemRepository:BaseRepository,ISaleInvoiceItemRepository
    {
        public bool UpdateSaleInvoiceItems(DataTable table)
        {
            ds.Tables.Clear();
            ds.Tables.Add(table);
            adapter.InsertCommand = new SqlCommand("Insert into SellInvoiceItem(ItemId,StockRoomId,TracingFactor,Quantity,Fee,SellInvoiceId,Offer,Extras,NetPrice) Values(@ItemId,@StockRoomId,@TracingFactor,@Quantity,@Fee,@SellInvoiceId,@Offer,@Extras,@NetPrice)");
            adapter.InsertCommand.Connection = connection;
            adapter.InsertCommand.Parameters.Add("@ItemId", SqlDbType.Int, 15, "ItemId");
            adapter.InsertCommand.Parameters.Add("@StockRoomId", SqlDbType.Int, 15, "StockRoomId");
            adapter.InsertCommand.Parameters.Add("@TracingFactor", SqlDbType.NVarChar, 15, "TracingFactor");
            adapter.InsertCommand.Parameters.Add("@Quantity", SqlDbType.Int, 15, "Quantity");
            adapter.InsertCommand.Parameters.Add("@Fee", SqlDbType.Int, 15, "Fee");
            adapter.InsertCommand.Parameters.Add("@SellInvoiceId", SqlDbType.Int, 15, "SellInvoiceId");
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
        public bool RemoveSaleInvoiceItems(int sellInvoiceId)
        {
            command.Connection = connection;
            command.CommandText = "delete from SellInvoiceItem where SellInvoiceId=@Id";
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@Id", sellInvoiceId);
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
        public List<SaleInvoiceItemModel> GetSaleInvoiceItems(int sellInvoiceId)
        {
            command.Connection = connection;
            command.CommandText = "select * from SellInvoiceItem  where SellInvoiceId=@SellInvoiceId";
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@SellInvoiceId", sellInvoiceId);
            connection.Open();
            adapter.SelectCommand = command;
            ds.Clear();
            adapter.Fill(ds, "SellInvoiceItem");
            connection.Close();
            return ds.Tables["SellInvoiceItem"].Rows.Cast<DataRow>().Select(r=>new SaleInvoiceItemModel() {SellInvoiceItemId=(int)r["SellInvoiceItemId"], ItemId = (int)r["ItemId"], SellInvoiceId=(int)r["SellInvoiceId"],Quantity= (int)r["Quantity"],StockRoomId= (int)r["StockRoomId"],TracingFactor= r["TracingFactor"].ToString() }).ToList();
        }
    }
}
