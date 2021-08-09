using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Utility.Interfaces;

namespace Project.Repositories
{
    public class StockRoomRepository :  BaseRepository,IStockRoomRepository
    {
        public StockRoomRepository()
        {
        }
        public DataTable GetData(int srId = 0)
        {
            if (srId == 0)
                command = new SqlCommand("select * from StockRoom ", connection);
            else
            {
                command.Connection = connection;
                command.CommandText = "select * from StockRoom where CAST(SRId as varchar) like '%'+@Id+'%'";
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@Id", srId.ToString());
            }
            connection.Open();
            adapter.SelectCommand = command;
            ds.Clear();
            adapter.Fill(ds, "StockRoom");
            connection.Close();
            return ds.Tables["StockRoom"];
        }

        public DataTable GetData(int SRId=0,int itemId=0)
        {
            command.Connection = connection;
            command.Parameters.Clear();
            if (SRId > 0)
            {  
                command.CommandText = "select * from StockRoom where CAST(SRId as varchar) like '%'+@Id+'%'";
                command.Parameters.AddWithValue("@Id", itemId.ToString());
                if(itemId>0)
                {
                    command.CommandText = "select * from StockRoom as s inner join StockItem as si on si.StockRoomId=s.StockRoomId where CAST(SRId as varchar) like '%'+@Id+'%' and CAST(ItemId as varchar) like '%'+@ItemId+'%'";
                    command.Parameters.AddWithValue("@ItemId", itemId.ToString());
                }
            }
            else
                command = new SqlCommand("select * from StockRoom ", connection);
            connection.Open();
            adapter.SelectCommand = command;
            ds.Clear();
            adapter.Fill(ds, "StockRoom");
            connection.Close();
            return ds.Tables["StockRoom"];
        }
    }
}
