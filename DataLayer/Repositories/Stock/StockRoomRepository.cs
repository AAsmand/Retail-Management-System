using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;


namespace Project.Repositories
{
    public class StockRoomRepository :  BaseRepository, IChooseRepository
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

        public DataTable GetDataToChoose(params object[] parameter)
        {
            command.Connection = connection;
            command.Parameters.Clear();
            if (parameter.Length > 0 && (int)parameter[0] > 0)
            {  
                command.CommandText = "select * from StockRoom where CAST(SRId as varchar) like '%'+@Id+'%'";
                command.Parameters.AddWithValue("@Id", parameter[0].ToString());
                if(parameter.Length>1 && (int)parameter[1]>0)
                {
                    command.CommandText = "select * from StockRoom as s inner join StockItem as si on si.StockRoomId=s.StockRoomId where CAST(SRId as varchar) like '%'+@Id+'%' and CAST(ItemId as varchar) like '%'+@ItemId+'%'";
                    command.Parameters.AddWithValue("@ItemId", parameter[1].ToString());
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
