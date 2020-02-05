using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace TestReq
{
    class Class1
    {
        public async Task Start()
        {
            //HttpClient httpClient = new HttpClient();
            //Uri uri = new Uri("http://www.bungie.net/Platform/Destiny/2/Stats/GetMembershipIdByDisplayName/facman47/");
            ////httpClient.BaseAddress = uri;
            
            //Task<HttpResponseMessage> task = httpClient.GetAsync(
            //    "http://www.bungie.net/Platform/Destiny/2/Stats/GetMembershipIdByDisplayName/facman47/");
            //Console.WriteLine(task.Result.Content);
            ////
            HttpClient httpClient = new HttpClient();
            string key = File.ReadAllText(@"C:\Users\Ivan\Documents\DestinyWebApp\DestinyWeb\Destiny-back\TestReq\Key.txt");
            httpClient.DefaultRequestHeaders.Add("X-API-Key", key);

            //var result = httpClient.GetAsync("http://www.bungie.net/Platform/Destiny/2/Stats/GetMembershipIdByDisplayName/facman47/").Result;

            var result = httpClient.GetAsync("http://www.bungie.net/Platform//Destiny2/Manifest/DestinyInventoryItemDefinition/3588655854/").Result;
            HttpContent httpContent = result.Content;
            var json = await httpContent.ReadAsStringAsync();
            string json1 = JsonConvert.SerializeObject(json);

            JsonTextReader reader = new JsonTextReader(new StringReader(json));
            while (reader.Read())
            {
                if (reader.Value != null)
                {
                    Console.WriteLine("Token: {0}, Value: {1}", reader.TokenType, reader.Value);
                }
                else
                {
                    Console.WriteLine("Token: {0}", reader.TokenType);
                }
            }
            File.WriteAllText(@"C:\Users\Ivan\Documents\DestinyWebApp\DestinyWeb\Destiny-back\TestReq\Jsons\item1.json", json);
            //Console.WriteLine(result.Content.ReadAsStringAsync().Result);
            Console.WriteLine(json1);

        }
    }
}
