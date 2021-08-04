﻿using Project.Models.User;
using Project.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Project.Repositories
{
    public class BuyInvoiceRepository:BaseRepository
    {
        public BuyInvoiceRepository()
        {
        }

        public  DataTable GetData()
        {

            command.Connection = connection;
            command.CommandText = "select BuyInvoiceId,SRId,Supplier,UserId,CreatedDate,CAST(TimeStamp as int) as TimeStamp from BuyInvoice";
            command.Parameters.Clear();
            connection.Open();
            adapter.SelectCommand = command;
            ds.Clear();
            adapter.Fill(ds, "BuyInvoice");
            connection.Close();
            return ds.Tables["BuyInvoice"];
        }
        public  bool DeleteItem(int buyInvoiceId)
        {
            command.Connection = connection;
            command.CommandText = "delete from BuyInvoice where BuyInvoiceId=@Id";
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

        public  bool AddItem(BuyInvoiceViewModel model)
        {
            command.Connection = connection;
            command.CommandText = "insert into BuyInvoice(BuyInvoiceId,SRId,CreatedDate,Supplier,UserId) Values(@BuyInvoiceId,@SRId,@CreatedDate,@Supplier,@UserId)";
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@BuyInvoiceId", model.BuyInvoiceId);
            command.Parameters.AddWithValue("@SRId", model.SRId);
            command.Parameters.AddWithValue("@CreatedDate", model.CreatedDate);
            command.Parameters.AddWithValue("@Supplier", model.Supplier);
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
            command.CommandText = "select Top 1 BuyInvoiceId from BuyInvoice order by BuyInvoiceId desc";
            command.Parameters.Clear();
            connection.Open();
            adapter.SelectCommand = command;
            ds.Clear();
            adapter.Fill(ds, "BuyInvoice");
            connection.Close();
            if (ds.Tables["BuyInvoice"].Rows.Count == 0)
                return 0;
            else return int.Parse(ds.Tables["BuyInvoice"].Rows[0]["BuyInvoiceId"].ToString());
        }

        public override bool IsNotConcurrent(IConcurrency model)
        {
            command.Connection = connection;
            command.CommandText = "select * from BuyInvoice where BuyInvoiceId=@BuyInvoiceId and CAST(TimeStamp as int)=@TimeStamp";
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@BuyInvoiceId", model.Id);
            command.Parameters.AddWithValue("@TimeStamp", model.TimeStamp);
            connection.Open();
            adapter.SelectCommand = command;
            ds.Clear();
            adapter.Fill(ds, "BuyInvoiceTimeStamp");
            connection.Close();
            if (ds.Tables["BuyInvoiceTimeStamp"].Rows.Count > 0)
                return true;
            return false;
        }
        //public static bool EditItem(ItemModel model)
        //{
        //    command.Connection = connection;
        //    command.CommandText = "update Item set Title=@Title, Description=@Description, RefUnitId=@RefUnitId ,TracingFactorId=@TracingFactorId ,pic=@pic where ItemId=@Id";
        //    command.Parameters.Clear();
        //    command.Parameters.AddWithValue("@Id", model.ItemId);
        //    command.Parameters.AddWithValue("@Title", model.Title);
        //    command.Parameters.AddWithValue("@Description", model.Description);
        //    command.Parameters.AddWithValue("@RefUnitId", model.RefUnitId);
        //    command.Parameters.AddWithValue("@TracingFactorId", model.TracingFactorId);
        //    command.Parameters.AddWithValue("@pic", model.Pic);
        //    connection.Open();
        //    if (command.ExecuteNonQuery() > 0)
        //    {
        //        connection.Close();
        //        return true;
        //    }
        //    connection.Close();
        //    return false;
        //}
    }
}