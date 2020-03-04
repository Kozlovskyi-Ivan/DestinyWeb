using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Linq;
using TestReq.EntityType;

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
            //var result = httpClient.GetAsync("http://www.bungie.net/Platform//Destiny2/Manifest/DestinyInventoryItemDefinition/534869653/").Result;

            //var result = httpClient.GetAsync("http://www.bungie.net/Platform//Destiny2/Manifest/DestinyMilestoneDefinition/3660836525/").Result;
            //var result = httpClient.GetAsync("http://www.bungie.net/Platform/Destiny2/Milestones/3915793660/Content/").Result;
            //var result = httpClient.GetAsync("http://www.bungie.net/Platform///Destiny2/Manifest/DestinyActivityDefinition/2693136605/").Result;
            var result = httpClient.GetAsync("http://www.bungie.net/Platform/Destiny2/Milestones/").Result;

            HttpContent httpContent = result.Content;
            var json = await httpContent.ReadAsStringAsync();
            //string json1 = JsonConvert.SerializeObject(json);
            //File.WriteAllText(@"C:\Users\Ivan\Documents\DestinyWebApp\DestinyWeb\Destiny-back\TestReq\Jsons\Milestones.json", json);
            //return;
            JObject jObject = JObject.Parse(json);

            //IList<JToken> result1 = jObject["Response"].Children().ToList();

            IList<JToken> result1 = jObject["Response"].Children().Children().ToList();

            List<DestinyPublicMilestone> Milestone=new List<DestinyPublicMilestone>();

            foreach (var item in result1)
            {
                try
                {
                    var temp = item.ToObject<DestinyPublicMilestone>();
                    Milestone.Add(temp);
                }
                catch (Newtonsoft.Json.JsonReaderException e)
                {
                    
                    Console.WriteLine();
                }
                catch(JsonSerializationException e)
                {
                    Console.WriteLine();
                }
                ////var def = httpClient.GetAsync(String.Concat("http://www.bungie.net/Platform//Destiny2/Manifest/DestinyMilestoneDefinition/", temp.milestoneHash, "/")).Result;
                //var def = httpClient.GetAsync(String.Concat($"http://www.bungie.net/Platform//Destiny2/Manifest/DestinyMilestoneDefinition/{temp.milestoneHash}/")).Result;
                //HttpContent httpContent1 = def.Content;
                //var json1 = await httpContent1.ReadAsStringAsync();
                ////Console.WriteLine(temp.milestoneHash);
                //File.WriteAllText(($@"C:\Users\Ivan\Documents\DestinyWebApp\DestinyWeb\Destiny-back\TestReq\Definitions\{temp.milestoneHash}.json"), json1);
            }

            //JsonTextReader reader = new JsonTextReader(new StringReader(json));
            //while (reader.Read())
            //{
            //    if (reader.Value != null)
            //    {
            //        Console.WriteLine("Token: {0}, Value: {1}", reader.TokenType, reader.Value);
            //    }
            //    else
            //    {
            //        Console.WriteLine("Token: {0}", reader.TokenType);
            //    }
            //}

            //File.WriteAllText(@"C:\Users\Ivan\Documents\DestinyWebApp\DestinyWeb\Destiny-back\TestReq\Jsons\temp.json", json);
            //Console.WriteLine(result.Content.ReadAsStringAsync().Result);
            //Console.WriteLine(json1);

            //IList<DestinyPublicMilestone> Results = new List<DestinyPublicMilestone>();
            //foreach (JToken res in result1)
            //{
            //    // JToken.ToObject is a helper method that uses JsonSerializer internally
            //    DestinyPublicMilestone Result = res.ToObject<DestinyPublicMilestone>();
            //    Results.Add(Result);
            //}

            //DestinyPublicMilestone milestone = JsonConvert.DeserializeObject<DestinyPublicMilestone>(json);
            Console.WriteLine(Milestone.FirstOrDefault(x=>((MyEnum)x.milestoneHash==MyEnum.Flashpoint)).milestoneHash);
            Console.WriteLine("OK");

        }
    }
}
