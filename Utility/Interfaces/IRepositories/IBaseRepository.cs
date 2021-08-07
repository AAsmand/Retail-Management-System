using Project.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Utility.Interfaces
{
    public interface IBaseRepository
    {
        SqlConnection connection { get; set; }
        SqlCommand command { get; set; }
        SqlDataAdapter adapter { get; set; }
        DataSet ds { get; set; }
        SqlDataReader dr { get; set; }
        bool IsNotConcurrent(IConcurrency model);
    }
}
