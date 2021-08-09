using Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Utility.Interfaces
{
    public interface IBaseUiView:IBase
    {
        DataTable GetData();
        List<DataGridViewColumn> GetColumn();
    }
}
