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
    class GetEntity
    {
        HttpClient httpClient;
        public GetEntity()
        {
            httpClient = new HttpClient();
            string key = File.ReadAllText(@"C:\Users\Ivan\Documents\DestinyWebApp\DestinyWeb\Destiny-back\TestReq\Key.txt");
            httpClient.DefaultRequestHeaders.Add("X-API-Key", key);
        }
        public async Task Start()
        {
            //HttpClient httpClient = new HttpClient();
            //string key = File.ReadAllText(@"C:\Users\Ivan\Documents\DestinyWebApp\DestinyWeb\Destiny-back\TestReq\Key.txt");
            //httpClient.DefaultRequestHeaders.Add("X-API-Key", key);

            var result = httpClient.GetAsync("http://www.bungie.net/Platform/Destiny2/Milestones/").Result;

            HttpContent httpContent = result.Content;
            var json = await httpContent.ReadAsStringAsync();
            JObject jObject = JObject.Parse(json);

            IList<JToken> parseJson = jObject["Response"].Children().Children().ToList();

            List<DestinyPublicMilestone> Milestone = new List<DestinyPublicMilestone>();

            foreach (var item in parseJson)
            {
                try
                {
                    var temp = item.ToObject<DestinyPublicMilestone>();
                    Milestone.Add(temp);
                }
                catch (JsonReaderException e)
                {

                    Console.WriteLine("asd");
                }
                catch (JsonSerializationException e)
                {
                    Console.WriteLine("asd");
                }
            }

            LoadQuest(Milestone);
            Loadactivities(Milestone);
            //var result2 = httpClient.GetAsync("http://www.bungie.net/Platform/Destiny2/Manifest/DestinyActivityDefinition/2693136601/").Result;
            //HttpContent httpContent2 = result2.Content;
            //var json2 = await httpContent2.ReadAsStringAsync();
            Console.WriteLine("OK");

        }

        private void LoadQuest(IList<DestinyPublicMilestone> milestones)
        {
            var quests = (from q in milestones
                          where q.availableQuests != null
                          from qi in q.availableQuests
                          select qi);
            Console.WriteLine();
            foreach (var item in quests)
            {
                Console.WriteLine(item.questItemHash);
            }
            Console.WriteLine();
        }

        private async void Loadactivities(IList<DestinyPublicMilestone> milestones)
        {
            var quests = (from a in milestones
                          where a.activities != null
                          from ah in a.activities
                          select ah);
            Console.WriteLine();
            foreach (var item in quests)
            {
                //Console.WriteLine(item.activityHash);
                if(item.modifierHashes!=null)
                foreach (var mod in item.modifierHashes)
                {
                    //Console.WriteLine(mod);
                }
            }
            var result = httpClient.GetAsync("http://www.bungie.net/Platform/Destiny2/Manifest/DestinyActivityDefinition/3879860661").Result;
            HttpContent httpContent = result.Content;
            var json = await httpContent.ReadAsStringAsync();
            File.WriteAllText(@"C:\Users\Ivan\Documents\DestinyWebApp\DestinyWeb\Destiny-back\TestReq\Activity.json", json);
            result = httpClient.GetAsync("http://www.bungie.net/Platform/Destiny2/Manifest/DestinyActivityModifierDefinition/605585258").Result;
            httpContent = result.Content;
            json = await httpContent.ReadAsStringAsync();
            File.WriteAllText(@"C:\Users\Ivan\Documents\DestinyWebApp\DestinyWeb\Destiny-back\TestReq\ActivityModifier.json", json);
            Console.WriteLine();
        }


    }
}
