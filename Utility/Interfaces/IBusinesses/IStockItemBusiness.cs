using Project.Repositories;
using Project.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Project.Business
{
    public interface IStockItemBusiness:IConcurrencyChecker
    {
        DataTable GetDataForChoose(params object[] parameters);
        StockItemViewModel GetStockItem(int stockItem);
    }
}
