using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace invoice.Proxy
{
    public class InvoiceProxy
    {
        public async Task<ResponseProxy<ClientModel>> GetFacturaAsync()
        {
            var client = new HttpClient();

            var urlBase = "https://localhost:44331";
            client.BaseAddress = new Uri(urlBase);

            var url = string.Concat(urlBase, "/Api", "/Invoice");
            var response = client.GetAsync(url).Result;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsStringAsync();
                var students = JsonConvert.DeserializeObject<List<ClientModel>>(result);

                return new ResponseProxy<ClientModel>
                {
                    Exitoso = true,
                    Codigo = (int)HttpStatusCode.OK,
                    Mensaje = "Exito",
                    listado = students
                };
            }
            else
            {
                return new ResponseProxy<ClientModel>
                {
                    Codigo = (int)response.StatusCode,
                    Mensaje = "Error"
                };
            }


        }
    }
}