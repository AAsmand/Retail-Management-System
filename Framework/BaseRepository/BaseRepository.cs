using Project.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Utility.Interfaces;

namespace Project.Repositories
{
    public class BaseRepository:IBaseRepository
    {
        public SqlConnection connection { get; set; }
        public SqlCommand command { get; set; }
        public SqlDataAdapter adapter { get; set; }
        public DataSet ds { get; set; }
        public SqlDataReader dr { get; set; }

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
