using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace invoice.Models
{
    public class ClientModel
    {
        public int idCliente { get; set; }
        public int nombreCliente { get; set; }
        public int dniCliente { get; set; }
        public int direccionCliente { get; set; }
        public int paisCliente { get; set; }

    }

}