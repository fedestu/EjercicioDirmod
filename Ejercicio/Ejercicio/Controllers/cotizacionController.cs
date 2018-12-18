using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Ejercicio.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Ejercicio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class cotizacionController : ControllerBase
    {
        private readonly ApplicationDbContext context;    

        public cotizacionController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<Cotizacionn> Get()
        {
            return context.Cotizaciones.ToList();
        }

        [HttpGet("{moneda}")]
        public async Task<IActionResult> GetByMonedaAsync(string moneda)
        {
            string valor = "";
            Cotizacionn cot = new Cotizacionn();

            if (moneda.Contains("euro"))
            {
                valor = "EUR";
                cot.Moneda = "euro";
            }
            if (moneda.Contains("dolar"))
            {
                valor = "USD";
                cot.Moneda = "dolar";
            }
            if (moneda.Contains("real"))
            {
                valor = "BRL";
                cot.Moneda = "real";
            }
            if (moneda.Contains("libra"))
            {
                valor = "GBP";
                cot.Moneda = "libra";
            }
            if (moneda.Contains("chileno"))
            {
                valor = "CLP";
                cot.Moneda = "peso chileno";
            }

            var url = "https://api.cambio.today/v1/quotes/"+ valor +"/ARS/json?quantity=1&key=1521|X**T^_R39LZhY35MRwzJyTNE_h6aZdks";
            var client = new HttpClient();
            var response = await client.GetAsync(url);
            var json = await response.Content.ReadAsStringAsync();
            dynamic model = JsonConvert.DeserializeObject(json);
            Moneda mon = model.result.ToObject<Moneda>();           

            cot.Precio = mon.amount;
            
            if(cot == null)
            {
                return NotFound();
            }

            return Ok(cot);
        }

        [HttpGet("{moneda}/{cantidad}")]
        public async Task<IActionResult> GetCambioAsync(string moneda, int cantidad)
        {
            string valor = "";
            Cambio cambio = new Cambio();

            if (moneda.Contains("euro"))
            {
                valor = "EUR";
                cambio.Moneda = "euro";
            }
            if (moneda.Contains("dolar"))
            {
                valor = "USD";
                cambio.Moneda = "dolar";
            }
            if (moneda.Contains("real"))
            {
                valor = "BRL";
                cambio.Moneda = "real";
            }
            if (moneda.Contains("libra"))
            {
                valor = "GBP";
                cambio.Moneda = "libra";
            }
            if (moneda.Contains("chileno"))
            {
                valor = "CLP";
                cambio.Moneda = "peso chileno";
            }

            var url = "https://api.cambio.today/v1/quotes/" + valor + "/ARS/json?quantity=1&key=1521|X**T^_R39LZhY35MRwzJyTNE_h6aZdks";
            var client = new HttpClient();
            var response = await client.GetAsync(url);
            var json = await response.Content.ReadAsStringAsync();
            dynamic model = JsonConvert.DeserializeObject(json);
            Moneda mon = model.result.ToObject<Moneda>();

            cambio.Precio = mon.amount;
            cambio.Cantidad = cantidad;
            cambio.PrecioCambio = mon.amount * cantidad;

            if (cambio == null)
            {
                return NotFound();
            }

            return Ok(cambio);
        }
    }
}