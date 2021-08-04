using Project.Business.ChooseBusiness;
using Project.Repositories;
using Project.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Project.Business
{
    public class SellTypeBusiness : IChooseBusiness
    {
        SellTypeRepository sellTypeRepository;
        public SellTypeBusiness()
        {
            sellTypeRepository = new SellTypeRepository();
        }
        public DataTable GetDataForChoose(params object[] parameters)
        {
            return sellTypeRepository.GetDataToChoose(parameters);
        }
        public SellTypeViewModel GetSellType(int sellTypeId)
        {
            return sellTypeRepository.GetData(sellTypeId).Rows.Cast<DataRow>().Select(r => new SellTypeViewModel() { SellTypeId = (int)r["SellTypeId"], SellTypeTitle = r["SellTypeTitle"].ToString() }).FirstOrDefault();
        }
    }
}
