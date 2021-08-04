using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Project.Models;

namespace Project.Repositories
{
    public  class SellTypeRepository:BaseRepository,IChooseRepository
    {
        public SellTypeRepository()
        {
        }
        public DataTable GetData(int sellTypeId=0)
        {
            if (sellTypeId == 0)
                command = new SqlCommand("select * from SellType", connection);
            else
            {

                command.Connection = connection;
                command.CommandText = "select * from SellType where CAST(SellTypeId as varchar) like '%'+@Id+'%'";
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@Id", sellTypeId.ToString());
            }
            connection.Open();
            adapter.SelectCommand = command;
            ds.Clear();
            adapter.Fill(ds, "SellType");
            connection.Close();
            return ds.Tables["SellType"];
        }

        public DataTable GetDataToChoose(params object[] parameter)
        {
            return GetData((int)parameter[0]);
        }
    }
}
