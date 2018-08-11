using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PcStoreApp.Models
{
    public class Product
    {
        public int ID { get; set; }

        [Display(Name = "Name of Products")]
        public string Name { get; set; }
        [Display(Name = "Quantity of Products")]
        public int Quantity { get; set; }
        [Display(Name = "Purchase Price")]
        public decimal PurchasePrice { get; set; }
        [Display(Name = "Sale Price")]
        public decimal SalePrice { get; set; }

    }
}