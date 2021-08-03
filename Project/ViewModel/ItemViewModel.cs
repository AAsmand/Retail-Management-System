using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project.ViewModel
{
    public class ItemViewModel
    {
        public int ItemId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int RefUnitId { get; set; }
        public string UnitName { get; set; }
        public bool HasTracingFactor { get; set; }
        public string TracingFactorId { get; set; }
        public string TracingFactorTitle { get; set; }
        public string Pic { get; set; }
        public int TimeStamp { get; set; }
        public int UserId { get; set; }
    }
}
