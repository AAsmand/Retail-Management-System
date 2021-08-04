using Project.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Project.Repositories
{
    public class BaseRepository
    {
        public SqlConnection connection;
        public SqlCommand command;
        public SqlDataAdapter adapter;
        public DataSet ds;
        public SqlDataReader dr;

        public BaseRepository()
        {
            connection = new SqlConnection("data source=.\\sepidar;Initial Catalog=ProjectDB2;User Id=damavand;Password=damavand");
            command = new SqlCommand();
            adapter = new SqlDataAdapter();
            ds = new DataSet();
        }
        public virtual bool IsNotConcurrent(IConcurrency model)
        {
            return true;
        }
    }
}
