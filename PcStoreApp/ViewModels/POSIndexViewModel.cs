using System;

namespace PcStoreApp.ViewModels
{
    public class POSIndexViewModel
    {
        public int ID { get; set; }
        public int Quantity { get; set; }
        public string ClientName { get; set; }
        public decimal SalePrise { get; set; }
        public string ProductName { get; set; }
        public DateTime Date { get; set; }
        public decimal Total { get; set; }
    }
}