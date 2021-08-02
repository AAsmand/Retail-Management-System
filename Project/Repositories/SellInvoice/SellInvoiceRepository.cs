using Project.Models;
using Project.Models.User;
using Project.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Project.Repositories
{
    public class SellInvoiceRepository:BaseRepository
    {
        public SellInvoiceRepository()
        {
        }

        public  DataTable GetData()
        {

            command.Connection = connection;
            command.CommandText = "select SellInvoiceId,s.SellTypeId,st.SellTypeTitle,Customer,UserId,CreatedDate,CAST(TimeStamp as int) as TimeStamp from SellInvoice as s inner join SellType as st on s.SellTypeId=st.SellTypeId";
            command.Parameters.Clear();
            connection.Open();
            adapter.SelectCommand = command;
            ds.Clear();
            adapter.Fill(ds, "SellInvoice");
            connection.Close();
            return ds.Tables["SellInvoice"];
        }
        public  bool DeleteItem(int sellInvoiceId)
        {
            command.Connection = connection;
            command.CommandText = "delete from SellInvoice where SellInvoiceId=@Id";
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

        public  bool AddItem(SellInvoiceViewModel model)
        {
            command.Connection = connection;
            command.CommandText = "insert into SellInvoice(SellInvoiceId,SellTypeId,CreatedDate,Customer,UserId) Values(@SellInvoiceId,@SellTypeId,@CreatedDate,@Customer,@UserId)";
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@SellInvoiceId", model.SellInvoiceId);
            command.Parameters.AddWithValue("@SellTypeId", model.SellTypeId);
            command.Parameters.AddWithValue("@CreatedDate", model.CreatedDate);
            command.Parameters.AddWithValue("@Customer", model.Customer);
            command.Parameters.AddWithValue("@UserId", UserModel.UserId);
            connection.Open();
            if (command.ExecuteNonQuery() > 0)
            {
                connection.Close();
                return true;
            }
            connection.Close();
            return false;
        }
        public  int GetLastId()
        {
            command.Connection = connection;
            command.CommandText = "select Top 1 SellInvoiceId from SellInvoice order by SellInvoiceId desc";
            command.Parameters.Clear();
            connection.Open();
            adapter.SelectCommand = command;
            ds.Clear();
            adapter.Fill(ds, "SellInvoice");
            connection.Close();
            if (ds.Tables["SellInvoice"].Rows.Count == 0)
                return 0;
            else return int.Parse(ds.Tables["SellInvoice"].Rows[0]["SellInvoiceId"].ToString());
        }
        public override bool IsNotConcurrent(IConcurrency model)
        {
            command.Connection = connection;
            command.CommandText = "select * from SellInvoice where SellInvoiceId=@SellInvoiceId and CAST(TimeStamp as int)=@TimeStamp";
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@SellInvoiceId", model.Id);
            command.Parameters.AddWithValue("@TimeStamp", model.TimeStamp);
            connection.Open();
            adapter.SelectCommand = command;
            ds.Clear();
            adapter.Fill(ds, "SellInvoiceTimeStamp");
            connection.Close();
            if (ds.Tables["SellInvoiceTimeStamp"].Rows.Count > 0)
                return true;
            return false;
        }
    }
}
