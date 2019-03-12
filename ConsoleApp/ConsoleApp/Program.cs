using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace ConsoleApp
{
    class Program
    {
        private static string token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.MTEzOQ.Rks0Y98Qrc8w36R0BMzLRj_eV_LRWdZfCKsNp_F4F3k";


        static void Main(string[] args)
        {
            Run();
            Console.ReadKey();
        }

        private static async void Run()
        {
            var dni = "76522916";

            var empresa = await ExecuteQuery(dni);

            Console.WriteLine($"PrimerNombre: {empresa["PrimerNombre"].Value<string>()}");
            Console.WriteLine($"SegundoNombre: {empresa["SegundoNombre"].Value<string>()}");
            Console.WriteLine($"ApellidoPaterno: {empresa["ApellidoPaterno"].Value<string>()}");
            Console.WriteLine($"ApellidoMaterno: {empresa["ApellidoMaterno"].Value<string>()}");

            /*
             
             {
                "PrimerNombre": "VICTOR",
                "SegundoNombre": "KEVIN",
                "ApellidoPaterno": "MATOS",
                "ApellidoMaterno": "SECCE"
             }
             */
        }
        private static async Task<JObject> ExecuteQuery(string NroDni)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                var result = await client.GetAsync("http://quertium.com/api/v1/reniec/dni/" + NroDni);
                result.EnsureSuccessStatusCode();
                var jsonString = await result.Content.ReadAsStringAsync();

                return JObject.Parse(jsonString);
            }
        }
    }
}
