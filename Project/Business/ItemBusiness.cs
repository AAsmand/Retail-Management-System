using Project.Models;
using Project.Repositories;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Project.Business
{
    public class ItemBusiness
    {
        private ItemRepository itemRepository;
        public ItemBusiness()
        {
            itemRepository = new ItemRepository();
        }
        public bool EditItem(int itemId,string title,string description,int refUnitId,bool hasTracingFactor,int tracingFactorId,string newPic,string oldPic, Image image, bool isUpdatedImage)
        {
            ItemModel Model = new ItemModel();
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
        public bool AddItem(string title, string description, int refUnitId,bool hasTracingFactor, int tracingFactorId, string pic, Image image)
        {
            ItemModel model = new ItemModel();
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
    }
}
