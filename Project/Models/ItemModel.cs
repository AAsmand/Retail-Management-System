using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project.Models
{
    public class ItemModel
    {
        public int ItemId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int RefUnitId { get; set; }
        public bool HasTracingFactor { get; set; }
        public int TracingFactorId { get; set; }
        public string Pic { get; set; }

    }
}
