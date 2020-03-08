using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Destiny_back.Modules.EntityTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Destiny_back.Modules
{
    public class ParseData
    {
        HttpClient httpClient;
        List<DestinyPublicMilestone> destinyPublics;
        public ParseData()
        {
            httpClient = new HttpClient();
            string key = File.ReadAllText(@"C:\Users\Ivan\Documents\DestinyWebApp\DestinyWeb\Destiny-back\TestReq\Key.txt");
            httpClient.DefaultRequestHeaders.Add("X-API-Key", key);
        }
        public void Start()
        {
            GetEntity();
            Console.WriteLine();
        }
        public async void GetEntity()
        {
            var result = httpClient.GetAsync("http://www.bungie.net/Platform/Destiny2/Milestones/").Result;

            HttpContent httpContent = result.Content;
            var json = await httpContent.ReadAsStringAsync();
            JObject jObject = JObject.Parse(json);

            IList<JToken> parseJson = jObject["Response"].Children().Children().ToList();

            //List<DestinyPublicMilestone> 
            destinyPublics = new List<DestinyPublicMilestone>();

            foreach (var item in parseJson)
            {
                try
                {
                    var temp = item.ToObject<DestinyPublicMilestone>();
                    destinyPublics.Add(temp);
                    if (temp.activities!=null)
                    {
                        foreach (var actes in temp.activities)
                        {
                            var Actresult = httpClient.GetAsync($"http://www.bungie.net/Platform/Destiny2/Manifest/DestinyActivityDefinition/{actes.activityHash}/").Result;

                            httpContent = Actresult.Content;
                            json = await httpContent.ReadAsStringAsync();
                            jObject = JObject.Parse(json);
                            DestinyPublicMilestoneChallengeActivity d= jObject["Response"].ToObject<DestinyPublicMilestoneChallengeActivity>();
                            //var asd=(string)jObject["Response"]["displayProperties"]["name"];
                            actes.displayProperties = d.displayProperties;
                            Console.WriteLine();
                            if (actes.modifierHashes!=null)
                            {
                                foreach (var modes in actes.modifierHashes)
                                {
                                    var qresult = httpClient.GetAsync($"http://www.bungie.net/Platform/Destiny2/Manifest/DestinyActivityModifierDefinition/{modes}/").Result;

                                    httpContent = qresult.Content;
                                    json = await httpContent.ReadAsStringAsync();
                                    jObject = JObject.Parse(json);
                                    //DestinyActivityModifierDefinition dasd= 
                                    //    new DestinyActivityModifierDefinition { modifierHashes = modes, 
                                    //        displayProperties = jObject["Response"]["displayProperties"].ToObject<DestinyDisplayPropertiesDefinition>() };
                                    //actes.modifiers.Add(dasd);
                                    actes.modifiers.Add(new DestinyActivityModifierDefinition { modifierHashes = modes, displayProperties = jObject["Response"]["displayProperties"].ToObject<DestinyDisplayPropertiesDefinition>() });
                                }
                            }
                        }
                    }
                    if (temp.availableQuests!=null)
                    {
                        foreach (var quests in temp.availableQuests)
                        {
                            var qresult = httpClient.GetAsync($"http://www.bungie.net/Platform/Destiny2/Manifest/DestinyMilestoneDefinition/{temp.milestoneHash}/").Result;

                            httpContent = qresult.Content;
                            json = await httpContent.ReadAsStringAsync();
                            jObject = JObject.Parse(json);
                            quests.displayProperties= jObject["Response"]["quests"][$"{quests.questItemHash}"]["displayProperties"].ToObject<DestinyDisplayPropertiesDefinition>();

                            Console.WriteLine();
                        }
                    }

                }
                catch (JsonReaderException e)
                {

                    //Console.WriteLine("asd");
                }
                catch (JsonSerializationException e)
                {
                    //Console.WriteLine("asd");
                }
            }
        }
    }
}
