using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project.Models
{
    public class SellInvoiceModel
    {
        public int SellInvoiceId { get; set; }
        public int SellTypeId { get; set; }
        public string Customer { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
