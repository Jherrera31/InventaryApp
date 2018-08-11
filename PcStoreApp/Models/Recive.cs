using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PcStoreApp.Models
{
    public class Recive 
    {
        public int ID { get; set; }
        public string Customer { get; set; }
        public DateTime Date { get; set; }
        public decimal Total { get; set; }
        public int Quantity { get; set; }
        
        public int ProductId { get; set; }
        public Product Product { get; set; }


    }
}