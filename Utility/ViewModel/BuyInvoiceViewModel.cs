using Project.Repositories.TypedData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project.ViewModel
{
    public class BuyInvoiceViewModel:IConcurrency
    {
        public string BuyInvoiceId { get; set; }
        public string SRId { get; set; }
        public string Supplier { get; set; }
        public string UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int TimeStamp { get; set; }
        public int Id { get => int.Parse(BuyInvoiceId); set => BuyInvoiceId=value.ToString(); }
        public BuyInvoiceItemDataTable ItemList { get; set; }
    }
}
