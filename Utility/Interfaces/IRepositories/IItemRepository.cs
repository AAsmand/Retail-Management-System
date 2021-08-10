using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Project.Models;
using Project.ViewModel;

namespace Utility.Interfaces
{
    public interface IItemRepository:IBaseRepository
    {
        DataTable GetItemsByFilter(int itemId = 0);
        bool DeleteItem(int itemId);
        bool AddItem(ItemViewModel model);
        bool EditItem(ItemViewModel model);
        DataTable GetItem(int itemId);
    }
}
