using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Project.Models;
using Project.ViewModel;
using Project.Models.User;
using Utility.Interfaces;

namespace Project.Repositories
{
    public  class ItemRepository:BaseRepository,IItemRepository
    {
        public ItemRepository()
        {
        }
        public DataTable GetData(int itemId=0)
        {
            if (itemId==0)
                command = new SqlCommand("select ItemId,i.Title,Description,RefUnitId,HasTracingFactor,i.TracingFactorId,pic,CreatorUserId,u.UnitName,t.Title as TracingFactorTitle , CAST(i.TimeStamp as int) as TimeStamp from Item as i inner join unit as u on u.UnitId=RefUnitId left join TracingFactor as t on t.TracingFactorId=i.TracingFactorId", connection);
            else
            {
                command.Connection = connection;
                command.CommandText = "select ItemId,i.Title,Description,RefUnitId,HasTracingFactor,i.TracingFactorId,pic,CreatorUserId,u.UnitName ,t.Title as TracingFactorTitle , CAST(i.TimeStamp as int) as TimeStamp from Item as i inner join unit as u on u.UnitId=RefUnitId left join TracingFactor as t on t.TracingFactorId=i.TracingFactorId where CAST(ItemId as varchar) like '%'+@Id+'%'";
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@Id", itemId.ToString());
            }
            connection.Open();
            adapter.SelectCommand = command;
            ds.Clear();
            adapter.Fill(ds, "Item");
            connection.Close();
            return ds.Tables["Item"];
        }
        public  bool DeleteItem(int itemId)
        {
            command.Connection = connection;
            command.CommandText = "delete from Item where ItemId=@Id";
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@Id", itemId);
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
        public  bool AddItem(ItemViewModel model)
        {
            command.Connection = connection;
            command.Parameters.Clear();
            if (model.HasTracingFactor)
            {
                command.CommandText = "insert into Item(Title,Description,RefUnitId,HasTracingFactor,TracingFactorId,pic,CreatorUserId) Values(@Title,@Description,@RefUnitId,@HasTracingFactor,@TracingFactorId,@pic,@CreatorUserId)";
                command.Parameters.AddWithValue("@TracingFactorId", model.TracingFactorId);
            }
            command.CommandText = "insert into Item(Title,Description,RefUnitId,HasTracingFactor,pic,CreatorUserId) Values(@Title,@Description,@RefUnitId,@HasTracingFactor,@pic,@CreatorUserId)";
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@Title", model.Title);
            command.Parameters.AddWithValue("@Description", model.Description);
            command.Parameters.AddWithValue("@RefUnitId", model.RefUnitId);
            command.Parameters.AddWithValue("@HasTracingFactor", model.HasTracingFactor);
            command.Parameters.AddWithValue("@pic", model.Pic);
            command.Parameters.AddWithValue("@CreatorUserId",UserModel.UserId);
            connection.Open();
            if (command.ExecuteNonQuery() > 0)
            {
                connection.Close();
                return true;
            }
            connection.Close();
            return false;
        }
        public  bool EditItem(ItemViewModel model)
        {
            command.Connection = connection;
            command.Parameters.Clear();
            if (model.HasTracingFactor)
            {
                command.CommandText = "update Item set Title=@Title, Description=@Description, RefUnitId=@RefUnitId ,HasTracingFactor=@HasTracingFactor,TracingFactorId=@TracingFactorId ,pic=@pic where ItemId=@Id";
                command.Parameters.AddWithValue("@TracingFactorId", model.TracingFactorId);
            }
            else
            {
                command.CommandText = "update Item set Title=@Title, Description=@Description, RefUnitId=@RefUnitId ,HasTracingFactor=@HasTracingFactor ,pic=@pic where ItemId=@Id";
            }
            command.Parameters.AddWithValue("@Id", model.ItemId);
            command.Parameters.AddWithValue("@Title", model.Title);
            command.Parameters.AddWithValue("@Description", model.Description);
            command.Parameters.AddWithValue("@RefUnitId", model.RefUnitId);
            command.Parameters.AddWithValue("@HasTracingFactor", model.HasTracingFactor);
            command.Parameters.AddWithValue("@pic", model.Pic);
            connection.Open();
            if (command.ExecuteNonQuery() > 0)
            {
                connection.Close();
                return true;
            }
            connection.Close();
            return false;
        }
        public  DataTable FindItem(int itemId)
        {

            command.Connection = connection;
            command.CommandText = "select TOP 1 ItemId,Title,Description,RefUnitId,HasTracingFactor,TracingFactorId,pic,CreatorUserId,CAST(TimeStamp as int) as TimeStamp from Item where ItemId=@Id";
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@Id", itemId);
            connection.Open();
            adapter.SelectCommand = command;
            ds.Clear();
            adapter.Fill(ds, "Item");
            connection.Close();
            return ds.Tables["Item"];
        }
        public override bool IsNotConcurrent(IConcurrency model)
        {
            command.Connection = connection;
            command.CommandText = "select * from Item where ItemId=@ItemId and CAST(TimeStamp as int)=@TimeStamp";
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@ItemId", model.Id);
            command.Parameters.AddWithValue("@TimeStamp", model.TimeStamp);
            connection.Open();
            adapter.SelectCommand = command;
            ds.Clear();
            adapter.Fill(ds, "ItemTimeStamp");
            connection.Close();
            if (ds.Tables["ItemTimeStamp"].Rows.Count > 0)
                return true;
            return false;
        }
    }
}
