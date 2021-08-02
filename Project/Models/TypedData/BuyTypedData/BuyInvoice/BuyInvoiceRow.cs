using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;

namespace Project.Repositories.TypedData
{
    public class BuyInvoiceRow : DataRow 
    {
        internal BuyInvoiceRow(DataRowBuilder builder) : base(builder)
        { 
        }
        #region Properties  
        public int BuyInvoiceItemId
        {
            get { return (int)base["BuyInvoiceItemId"]; }
            set { base["BuyInvoiceItemId"] = value; }
        }
        public int StockItemId
        {
            get { return (int)base["StockItemId"]; }
            set { base["StockItemId"] = value; }
        }
        [Required]
        public int ItemId
        {
            get { return (int)base["ItemId"]; }
            set { base["ItemId"] = value; }
        }
        public string ItemTitle
        {
            get { return (string)base["ItemTitle"]; }
            set { base["ItemTitle"] = value; }
        }
        public string TracingFactor
        {
            get { return (string)base["TracingFactor"]; }
            set { base["TracingFactor"] = value; }
        }
        public int Quantity
        {
            get { return (int)base["Quantity"]; }
            set { base["Quantity"] = value; }
        }
        public int Fee
        {
            get { return (int)base["Fee"]; }
            set { base["Fee"] = value; }
        }
        public int Total
        {
            get { return (int)base["Total"]; }
            set { base["Total"] = value; }
        }
        public int Offer
        {
            get { return (int)base["Offer"]; }
            set { base["Offer"] = value; }
        }
        public int Extras
        {
            get { return (int)base["Extras"]; }
            set { base["Extras"] = value; }
        }
        public int NetPrice
        {
            get { return (int)base["NetPrice"]; }
            set { base["NetPrice"] = value; }
        }
        public int BuyInvoiceId
        {
            get { return (int)base["BuyInvoiceId"]; }
            set { base["BuyInvoiceId"] = value; }
        }
        #endregion
    }
}
