using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Ejercicio.Models
{
    public class Clase
    {
        private readonly ApplicationDbContext context;
        public async Task GetServicesList()
        {
            var url = "https://api.cambio.today/v1/quotes/USD/ARS/json?quantity=1&key=1521|X**T^_R39LZhY35MRwzJyTNE_h6aZdks";
            var client = new HttpClient();
            var response = await client.GetAsync(url);
            var json = await response.Content.ReadAsStringAsync();
            var model = JsonConvert.DeserializeObject<ServiceResponse>(json);
            //var servicesList = model.result.Select(s => s.name.Replace("appData/", "")).ToArray();

        }

        public class Service
        {
            public string updated { get; set; }
            public string source { get; set; }
            public string target { get; set; }
            public double value { get; set; }
            public double quantity { get; set; }
            public double amount { get; set; }
        }

        public class ServiceResponse
        {
            public IList<Service> result { get; set; }
            public string status { get; set; }
        }
    }
}

