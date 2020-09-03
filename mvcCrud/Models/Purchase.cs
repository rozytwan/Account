using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace mvcCrud.Models
{
    public class Data : DbContext
    {
        public Data() : base("conn")
        {

        }
        public DbSet<Purchase> purchase { get; set; }
    }
    public class Purchase
    {
        public int purchase_id { get; set; }
        public string category_name{ get; set; }
        public string product_name { get; set; }
        public string po_no { get; set; }
    }
}