using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace mvcCrud.Models
{
    public class Datajoin : DbContext
    {
        public Datajoin() : base("conn")
        {

        }
        public DbSet<ProfitLoss> profitloss { get; set; }
    }
    public class ProfitLoss
    {
        public int category_id { get; set; }
        public string category_name { get; set; }
        public decimal amount { get; set; }
        public DateTime date { get; set; }
        public string status { get; set; }
        public string month { get; set; }
        public string description { get; set; }
    }
}