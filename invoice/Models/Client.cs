using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace invoice.Models
{
    public class Client
    {
        public int clientID { get; set; }
        public string name { get; set; }
        public int dni { get; set; }
        public string address { get; set; }
        public string country { get; set; }
    }
}