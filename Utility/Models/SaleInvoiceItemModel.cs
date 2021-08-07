using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project.Models
{
    public class SaleInvoiceItemModel
    {
        public int SellInvoiceItemId { get; set; }
        public int ItemId { get; set; }
        public int SellInvoiceId { get; set; }
        public int Quantity { get; set; }
        public int StockRoomId { get; set; }
        public string TracingFactor { get; set; }

    }
}
