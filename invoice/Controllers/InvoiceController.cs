using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using invoice.Models;

namespace invoice.Controllers
{
    public class InvoiceController : Controller
    {   
        // GET: Invoice
        Proxy.InvoiceProxy proxy = new Proxy.InvoiceProxy();

        public ActionResult Index()
        {
            var response = Task.Run(() => proxy.GetFacturaAsync());
            return View(response.Result.listado);
        }
       
        [HttpPost]
        public ActionResult InsertInvoice(Invoice std)
        {
            
            var response = Task.Run(() => proxy.InsertAsync(std));
            string message = response.Result.Mensaje;
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });

        }
    }
}