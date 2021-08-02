using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project.Models
{
    public class StockItemModel
    {
        public int StockItemId { get; set; }
        public int ItemId { get; set; }
        public int SRId { get; set; }
        public int StockValue { get; set; }
        public DateTime CreatedDate { get; set; }   
        public string TracingFactor { get; set; }

    }
}
