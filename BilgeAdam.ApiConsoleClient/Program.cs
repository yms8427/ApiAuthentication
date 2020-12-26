using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BilgeAdam.ApiConsoleClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:5001")
            };

            var json = JsonConvert.SerializeObject(new LoginInputModel { UserName = "can", Password = "123" });
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("api/account/login", content);
            var result = await responseMessage.Content.ReadAsStringAsync();
            Console.WriteLine(result);


            //TODO: get products
            Console.Read();
        }
    }

    public class LoginInputModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
