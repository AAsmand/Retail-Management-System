using Project.Repositories;
using Project.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Utility.Interfaces;

namespace Project.Business
{
    public class SaleTypeBusiness: ISaleTypeBusiness
    {
        ISaleTypeRepository saleTypeRepository;
        public SaleTypeBusiness(ISaleTypeRepository repository)
        {
            saleTypeRepository = repository;
        }
        public DataTable GetDataForChoose(params object[] parameters)
        {
            return saleTypeRepository.GetDataToChoose(parameters);
        }
        public SaleTypeViewModel GetSellType(int sellTypeId)
        {
            return saleTypeRepository.GetData(sellTypeId).Rows.Cast<DataRow>().Select(r => new SaleTypeViewModel() { SellTypeId = (int)r["SellTypeId"], SellTypeTitle = r["SellTypeTitle"].ToString() }).FirstOrDefault();
        }
    }
}
