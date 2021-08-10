using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Utility.Interfaces;

namespace Project.Repositories
{
    public class UnitRepository:BaseRepository,IUnitRepository
    {
        public DataTable GetUnits()
        {

            command.Connection = connection;
            command.CommandText = "select * from unit";
            command.Parameters.Clear();
            connection.Open();
            adapter.SelectCommand = command;
            ds.Clear();
            adapter.Fill(ds, "unit");
            connection.Close();
            return ds.Tables["unit"];
        }
    }
}
