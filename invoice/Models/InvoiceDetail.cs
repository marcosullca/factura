using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace invoice.Models
{
    public class InvoiceDetail
    {
        public int invoicedetailID { get; set; }
        public Invoice Invoice { get; set; }
        public Product Product { get; set; }
        public int quantity { get; set; }
        public double price { get; set; }
    }
}