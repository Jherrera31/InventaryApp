using PcStoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PcStoreApp.ViewModels
{
    public class POSCreateViewModel
    {
        public int Quantity { get; set; }
        public string ClientName { get; set; }
        public int ProductId { get; set; }
        public IEnumerable<SelectListItem> ProductsSelectList { get; set; }
    }
}