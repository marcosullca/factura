using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using invoice.Models;
using Newtonsoft.Json;

namespace invoice.Proxy
{
    public class InvoiceProxy
    {
        static string urlBase = "https://localhost:44359";
        public async Task<ResponseProxy<Invoice>> GetFacturaAsync()
        {
            var client = new HttpClient();

            client.BaseAddress = new Uri(urlBase);

            var url = string.Concat(urlBase, "/Api", "/Invoice");
            var response = client.GetAsync(url).Result;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsStringAsync();
                var invoices = JsonConvert.DeserializeObject<List<Invoice>>(result);

                return new ResponseProxy<Invoice>
                {
                    Exitoso = true,
                    Codigo = (int)HttpStatusCode.OK,
                    Mensaje = "Exito",
                    listado = invoices
                };
            }
            else
            {
                return new ResponseProxy<Invoice>
                {
                    Codigo = (int)response.StatusCode,
                    Mensaje = "Error"
                };
            }


        }

        public async Task<ResponseProxy<Invoice>> InsertAsync(Invoice model)
        {
            var request = JsonConvert.SerializeObject(model);
            var content = new StringContent(request, Encoding.UTF8, "application/json");
            var client = new HttpClient();


            client.BaseAddress = new Uri(urlBase);
            var url = string.Concat(urlBase, "/Api", "/Invoice","/InsertInvoice");

            var response = client.PostAsync(url, content).Result;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsStringAsync();
                var exito = JsonConvert.DeserializeObject<bool>(result);

                return new ResponseProxy<Invoice>
                {
                    Exitoso = exito,
                    Codigo = 0,
                    Mensaje = "Exito"
                };
            }
            else
            {
                return new ResponseProxy<Invoice>
                {
                    Exitoso = false,
                    Codigo = (int)response.StatusCode,
                    Mensaje = "Error"
                };
            }
        }


        public async Task<ResponseProxy<Invoice>> Search(SearchInvoice searchInvoice)
        {
            var request = JsonConvert.SerializeObject(searchInvoice);
            var content = new StringContent(request, Encoding.UTF8, "application/json");
            var client = new HttpClient();


            client.BaseAddress = new Uri(urlBase);
            var url = string.Concat(urlBase, "/search");

            var response = client.PostAsync(url, content).Result;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsStringAsync();
                var exito = JsonConvert.DeserializeObject<bool>(result);

                return new ResponseProxy<Invoice>
                {
                    Exitoso = exito,
                    Codigo = 0,
                    Mensaje = "Exito"
                };
            }
            else
            {
                return new ResponseProxy<Invoice>
                {
                    Exitoso = false,
                    Codigo = (int)response.StatusCode,
                    Mensaje = "Error"
                };
            }
        }




    }
}