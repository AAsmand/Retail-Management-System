using Project.Repositories.TypedData;
using Project.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project.ViewModel
{
    public class SellInvoiceViewModel:IConcurrency
    {
        public int SellInvoiceId { get; set; }
        public int SellTypeId { get; set; }
        public string SellTypeTitle { get; set; }
        public string Customer { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UserId { get; set; }
        public int TimeStamp { get; set; }
        public SellInvoiceItemDataTable ItemTable { get; set; }
        public int Id { get => SellInvoiceId; set => SellInvoiceId = value; }
    }
}
