using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Project.Models;
using Project.ViewModel;
using Project.Models.User;

namespace Utility.Interfaces
{
    public interface IItemRepository:IBaseRepository,IChooseRepository
    {
        DataTable GetData(int itemId = 0);
        bool DeleteItem(int itemId);
        bool AddItem(ItemViewModel model);
        bool EditItem(ItemViewModel model);
        DataTable FindItem(int itemId);
    }
}
