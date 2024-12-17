using Microsoft.AspNetCore.Mvc;

using System.Net.Http.Headers;

using WebApplication1.Dto;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DolarController : ControllerBase
    {



        [HttpGet()]
        public async Task<string> Get()
        {


            string responseBody = string.Empty;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://dolarapi.com/v1/dolares/blue");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue
               ("application/json"));

                HttpResponseMessage response = await client.GetAsync(client.BaseAddress);
                response.EnsureSuccessStatusCode();
                responseBody = response.Content.ReadAsStringAsync().Result;
            }

            return responseBody;
        }



        [HttpPost()]
        public async Task<string> Post(Currency currency)
        {
            Dictionary<string, string> currenciesdictionary = new Dictionary<string, string>();
            currenciesdictionary.Add("bolsa", "https://dolarapi.com/v1/dolares/bolsa");
            currenciesdictionary.Add("blue", "https://dolarapi.com/v1/dolares/blue");
            currenciesdictionary.Add("cripto", "https://dolarapi.com/v1/dolares/cripto");

            string Currency = string.Empty;
            string responseBody = string.Empty;
            string paraobtenciondemonedas = currenciesdictionary[currency.Code];
            using (var client = new HttpClient())

            {

                client.BaseAddress = new Uri(paraobtenciondemonedas);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue
               ("application/json"));

                HttpResponseMessage response = await client.GetAsync(client.BaseAddress);
                response.EnsureSuccessStatusCode();
                responseBody = response.Content.ReadAsStringAsync().Result;
            }
            return responseBody;
        }
    }

}

