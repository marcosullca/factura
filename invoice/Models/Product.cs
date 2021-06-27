using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace invoice.Models
{
    public class Product
    {
        public int productID { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public int stock { get; set; }
    }
}