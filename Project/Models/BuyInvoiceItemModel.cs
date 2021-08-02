using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project.Models
{
    public class BuyInvoiceItemModel
    {
        public int BuyInvoiceItemId { get; set; }
        public int BuyInvoiceId { get; set; }
        public int Quantity { get; set; }
        public int StockItemId { get; set; }

    }
}
