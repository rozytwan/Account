using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mvcCrud.Models
{
  
    public class Product
    {
        
        public int id { get; set; }
        [Required]
        [StringLength(8, ErrorMessage = "Do not Enter More Than 8 Character"), MinLength(2, ErrorMessage = "Character Must Be Greater Than 1")]
        public string productname { get; set; }
        [Required]
        public int serialnumber { get; set; }
    }

    public class Login
    {
        public int id { get; set; }
        //[Required]
        public string username { get; set; }

        public string password { get; set; }
    }

}