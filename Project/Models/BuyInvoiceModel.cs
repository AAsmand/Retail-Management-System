using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project.Models
{
    public class BuyInvoiceModel
    {
        public int BuyInvoiceId { get; set; }
        public int SRId { get; set; }
        public string Supplier { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsFinally { get; set; }
    }
}
