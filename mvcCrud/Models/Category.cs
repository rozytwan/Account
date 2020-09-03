using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace mvcCrud.Models
{
    public class DataContent : DbContext
    {
        public DataContent() : base("conn")
        {

        }
        public DbSet<Category> category { get; set; }
    }
    public class Category
    {
        public int category_id { get; set; }
        [Required(ErrorMessage = "Field Required")]
        public string category_name { get; set; }
        public string category_type { get; set; }
        [Required(ErrorMessage = "Field Required")]
        public string category_code { get; set; }
    }
}