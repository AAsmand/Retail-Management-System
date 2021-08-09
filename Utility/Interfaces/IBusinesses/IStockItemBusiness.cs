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
        DataTable GetData(int itemId = 0, int SRId = 0, string tracingFactor = "");
        StockItemViewModel GetStockItem(int stockItem);
    }
}
