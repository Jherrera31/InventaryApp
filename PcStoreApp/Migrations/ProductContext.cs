using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PcStoreApp.Models
{
    public class ProductContext : DbContext
    {

       public ProductContext() 
       : base ("name= DbContext")
        {
            
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Recive> Recives { get; set; }
    }
}