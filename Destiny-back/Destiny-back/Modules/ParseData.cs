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
        //ApplicationContext context;
        public ParseData()
        {
            httpClient = new HttpClient();
            string key = File.ReadAllText(@"C:\Users\Ivan\Documents\DestinyWebApp\DestinyWeb\Destiny-back\TestReq\Key.txt");
            httpClient.DefaultRequestHeaders.Add("X-API-Key", key);
        }
        public void Start()
        {
            using (var db=new ApplicationContext())
            {
                if (!db.Milestones.Any() || db.Milestones.First((x)=>x.name=="Leviathan Raid").EndDate<DateTime.UtcNow)
                {
                    Console.WriteLine();
                    //if (db.Milestones==null)
                    {
                        db.RemoveRange(db.Milestones);
                        db.SaveChanges();
                    }
                    //db.RemoveRange(db.Milestones);
                    //db.SaveChanges();
                    GetEntity();
                    EntetyToDb();
                }
            }
            //GetEntity();
            //EntetyToDb();

        }

        public void EntetyToDb()
        {
            using (var Db=new ApplicationContext())
            {
                foreach (var milestone in destinyPublics)
                {
                    Milestone mile = new Milestone() {
                        Hash=milestone.milestoneHash,
                        StartDate=milestone.startDate,
                        EndDate=milestone.endDate };
                    if (milestone.displayProperties!=null)
                    {
                        mile.description = milestone.displayProperties.description;
                        mile.name = milestone.displayProperties.name;
                    }

                    if (milestone.activities!=null)
                    {
                        List<Activity> activities = new List<Activity>();
                        foreach (var activity in milestone.activities)
                        {
                            Activity activityTemp = new Activity { 
                                ActivityHash=activity.activityHash,
                                name=activity.displayProperties.name,
                                description=activity.displayProperties.description};
                            if (activity.modifiers != null)
                            {
                                List<Modifier> modifiers = new List<Modifier>();
                                foreach (var mod in activity.modifiers)
                                {
                                    modifiers.Add(new Modifier { 
                                        name=mod.displayProperties.name,
                                        description=mod.displayProperties.description,
                                        ModifierHash=mod.modifierHashes});
                                }
                                
                                activityTemp.Modifiers = modifiers;
                            }
                            activities.Add(activityTemp);
                        }
                        mile.Activities = activities;
                        
                    }
                    if (milestone.vendors!=null)
                    {
                        foreach (var vendor in milestone.vendors)
                        {
                            mile.VendorHash = vendor.vendorHash;
                        }
                    }
                    if (milestone.availableQuests!=null)
                    {
                        foreach (var quests in milestone.availableQuests)
                        {
                            mile.QuestItemHash = quests.questItemHash;
                        }
                    }
                    Db.Milestones.Add(mile);
                    Db.SaveChanges();
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }
        public async void GetEntity()
        {
            JObject jObject = JObject.Parse(await GetRequestResult("http://www.bungie.net/Platform/Destiny2/Milestones/"));

            IList<JToken> parseJson = jObject["Response"].Children().Children().ToList();

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
                            jObject = JObject.Parse(await GetRequestResult($"http://www.bungie.net/Platform/Destiny2/Manifest/DestinyActivityDefinition/{actes.activityHash}/"));
                            DestinyPublicMilestoneChallengeActivity d= jObject["Response"].ToObject<DestinyPublicMilestoneChallengeActivity>();
                            actes.displayProperties = d.displayProperties;
                            if (actes.modifierHashes!=null)
                            {
                                foreach (var modes in actes.modifierHashes)
                                {
                                    jObject = JObject.Parse(await GetRequestResult($"http://www.bungie.net/Platform/Destiny2/Manifest/DestinyActivityModifierDefinition/{modes}/"));
                                    actes.modifiers.Add(new DestinyActivityModifierDefinition { modifierHashes = modes, displayProperties = jObject["Response"]["displayProperties"].ToObject<DestinyDisplayPropertiesDefinition>() });
                                }
                            }
                        }
                    }
                    jObject = JObject.Parse(await GetRequestResult($"http://www.bungie.net/Platform/Destiny2/Manifest/DestinyMilestoneDefinition/{temp.milestoneHash}/"));
                    temp.displayProperties = jObject["Response"]["displayProperties"].ToObject<DestinyDisplayPropertiesDefinition>();
                    if (temp.availableQuests!=null)
                    {
                        foreach (var quests in temp.availableQuests)
                        {
                            //quests.displayProperties = jObject["Response"]["quests"][$"{quests.questItemHash}"]["displayProperties"].ToObject<DestinyDisplayPropertiesDefinition>();
                            temp.displayProperties = jObject["Response"]["quests"][$"{quests.questItemHash}"]["displayProperties"].ToObject<DestinyDisplayPropertiesDefinition>();
                        }
                    }

                }
                catch (JsonReaderException e)
                {
                    
                }
                catch (JsonSerializationException e)
                {

                }
                catch (Exception e)
                {

                }
                
            }
        }

        public async Task<string> GetRequestResult(string url)
        {
            var Actresult = httpClient.GetAsync(url).Result;
            HttpContent httpContent = Actresult.Content;
            string json = await httpContent.ReadAsStringAsync();
            return json;
        }
    }
}
