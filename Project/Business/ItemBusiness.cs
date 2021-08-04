using Project.Business.ChooseBusiness;
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
using System.Transactions;
using System.Windows.Forms;

namespace Project.Business
{
    public class ItemBusiness:BaseBusiness<ItemViewModel,ItemRepository>,IChooseBusiness
    {
        private ItemRepository itemRepository;
        public ItemBusiness()
        {
            itemRepository = new ItemRepository();
        }
        public List<ItemViewModel> GetItems()
        {
            return itemRepository.GetData().Rows.Cast<DataRow>().Select(r => new ItemViewModel() { ItemId = (int)r["ItemId"], Title = r["Title"].ToString(), Description = r["Description"].ToString(), RefUnitId = (int)r["RefUnitId"], TimeStamp = (int)r["TimeStamp"], UserId = (int)r["CreatorUserId"], HasTracingFactor = !string.IsNullOrEmpty(r["HasTracingFactor"].ToString()) ? (bool)r["HasTracingFactor"] : false, TracingFactorId = r["TracingFactorId"].ToString(), UnitName = r["UnitName"].ToString(), TracingFactorTitle = r["TracingFactorTitle"].ToString(), Pic = r["pic"].ToString() }).ToList();
        }
        public bool EditItem(int itemId, string title, string description, int refUnitId, bool hasTracingFactor, string tracingFactorId, string newPic, string oldPic, Image image, bool isUpdatedImage)
        {
            ItemViewModel Model = new ItemViewModel();
            Model.ItemId = itemId;
            Model.Title = title;
            Model.Description = description;
            Model.RefUnitId = refUnitId;
            Model.HasTracingFactor = hasTracingFactor;
            Model.TracingFactorId = tracingFactorId;
            if (isUpdatedImage)
                Model.Pic = Guid.NewGuid().ToString() + Path.GetExtension(newPic);
            else
                Model.Pic = oldPic;
            try
            {
                if (itemRepository.EditItem(Model))
                {
                    if (isUpdatedImage)
                    {
                        string lastPath = Path.Combine(Application.StartupPath, "Images", oldPic);
                        string path = Path.Combine(Application.StartupPath, "Images", Model.Pic);
                        //if (File.Exists(lastPath))
                        //    File.Delete(lastPath);
                        image.Save(path);
                    }
                    return true;
                }
            }
            catch { }
            return false;
        }
        public bool AddItem(string title, string description, int refUnitId, bool hasTracingFactor, string tracingFactorId, string pic, Image image)
        {
            ItemViewModel model = new ItemViewModel();
            model.Title = title;
            model.Description = description;
            model.RefUnitId = refUnitId;
            model.HasTracingFactor = hasTracingFactor;
            model.TracingFactorId = tracingFactorId;
            model.Pic = Guid.NewGuid().ToString() + Path.GetExtension(pic);
            if (itemRepository.AddItem(model))
            {
                string path = Path.Combine(Application.StartupPath, "Images", model.Pic);
                image.Save(path);
                return true;
            }
            return false;
        }
        public bool RemoveItems(List<int> itemIds)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                foreach (int id in itemIds)
                {
                    if (!itemRepository.DeleteItem(id)) return false;
                }
                scope.Complete();
                return true;
            }
        }
        public ItemViewModel GetItem(int itemId)
        {
            DataTable item = itemRepository.FindItem(itemId);
            if (item.Rows.Count != 1)
            {
                return null;
            }
            return item.Rows.Cast<DataRow>().Select(r => new ItemViewModel() { ItemId = (int)r["ItemId"], Title = r["Title"].ToString(), Description = r["Description"].ToString(), TimeStamp = (int)r["TimeStamp"], UserId = (int)r["CreatorUserId"], HasTracingFactor = !string.IsNullOrEmpty(r["HasTracingFactor"].ToString()) ? (bool)r["HasTracingFactor"] : false, TracingFactorId = r["TracingFactorId"].ToString(), Pic = r["pic"].ToString() }).ToList()[0];
        }

        public DataTable GetDataForChoose(params object[] parameters)
        {
            return itemRepository.GetDataToChoose(parameters);
        }
    }
}
