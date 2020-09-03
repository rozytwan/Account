using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcCrud.Models
{
    public class Datatrans : DbContext
    {
        public Datatrans() : base("conn")
        {

        }
        public DbSet<Transaction> transaction { get; set; }
        public DbSet<Category> category { get; set; }
    }

    public class Transaction
    {
        public int trans_id { get; set; }
        public int category_id { get; set; }
        [Required]
        public string category_name { get; set; }
        [Required]
        public string description { get; set; }
        public string paymentmode { get; set; }
        [Required]
        [Range(0.01, 9999999999999999, ErrorMessage = "Price must be greater than 0.00")]
        public decimal amount { get; set; }
        [Required]
        public DateTime date { get; set; }
        public string fiscal_year { get; set; }
        public string status { get; set; }

    }

}