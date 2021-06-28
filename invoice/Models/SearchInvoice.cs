using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace invoice.Models
{
    public class SearchInvoice
    {
        public string client { get; set; }
        public string invoicecode { get; set; }
        public DateTime date_first { get; set; }
        public DateTime date_last { get; set; }
    }
}