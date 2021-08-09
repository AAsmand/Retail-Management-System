using Project.Models;
using Project.Repositories;
using Project.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace Project.Business
{
    public interface IItemBusiness:IConcurrencyChecker
    {
        List<ItemViewModel> GetItems();
        bool EditItem(int itemId, string title, string description, int refUnitId, bool hasTracingFactor, string tracingFactorId, string newPic, string oldPic, Image image, bool isUpdatedImage);
        bool AddItem(string title, string description, int refUnitId, bool hasTracingFactor, string tracingFactorId, string pic, Image image);
        bool RemoveItems(List<int> itemIds);
        ItemViewModel GetItem(int itemId);
        DataTable GetData(int id = 0);
    }
}
