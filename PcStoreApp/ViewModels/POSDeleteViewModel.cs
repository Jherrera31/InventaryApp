using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PcStoreApp.ViewModels
{
    public class POSDeleteViewModel
    {
        public int ID { get; set; }
        public string Customer { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal SalePrice { get; set; }
        public decimal Total { get; set; }
        public DateTime Date { get; set; }
    }
}