using System.Data;

namespace Project.Repositories.TypedData
{
    public class SellInvoiceItemDataRow : DataRow 
    {
        internal SellInvoiceItemDataRow(DataRowBuilder builder) : base(builder)
        { 
        }
        #region Properties  
        public int SellInvoiceItemId
        {
            get { return (int)base["SellInvoiceItemId"]; }
            set { base["SellInvoiceItemId"] = value; }
        }
        public int StockValue
        {
            get { return (int)base["StockValue"]; }
            set { base["StockValue"] = value; }
        }
        public int StockRoomId
        {
            get { return (int)base["StockRoomId"]; }
            set { base["StockRoomId"] = value; }
        }
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
            get { return (int)base["SellInvoiceId"]; }
            set { base["SellInvoiceId"] = value; }
        }
        public bool HasTracingFactor
        {
            get { return (bool)base["HasTracingFactor"]; }
            set { base["HasTracingFactor"] = value; }
        }
        #endregion
    }
}
