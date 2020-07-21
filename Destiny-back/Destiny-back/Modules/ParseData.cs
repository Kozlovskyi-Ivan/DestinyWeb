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
    public class ParseData : IDisposable
    {
        HttpClient httpClient;
        List<DestinyPublicMilestone> destinyPublics;
        bool disposed;
        //ApplicationContext context;
        public ParseData()
        {
            httpClient = new HttpClient();
            //string key = File.ReadAllText(@"C:\Users\Ivan\Documents\DestinyWebApp\DestinyWeb\Destiny-back\TestReq\Key.txt");


            string key = File.ReadAllText(@"./Key.txt");


            //string key = File.ReadAllText(@"/Key.txt");

            httpClient.DefaultRequestHeaders.Add("X-API-Key", key);
        }
        public void Start()
        {
            using (var db = new ApplicationContext())
            {
                if (!db.Milestones.Any() || db.Milestones.First((x) => x.name == "Last Wish Raid").EndDate < DateTime.UtcNow)
                {
                    Console.WriteLine();
                    if (db.Database.CanConnect())
                    {
                        db.RemoveRange(db.Milestones);
                        db.SaveChanges();
                    }
                    GetEntity();
                    EntetyToDb();
                }
            }
        }

        public void EntetyToDb()
        {
            using (var dbContext = new ApplicationContext())
            {
                foreach (var milestone in destinyPublics)
                {
                    MilestoneObjectToDB(milestone,dbContext);
                }
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
                    if (temp.activities != null)
                    {
                        foreach (var actes in temp.activities)
                        {
                            jObject = JObject.Parse(await GetRequestResult($"http://www.bungie.net/Platform/Destiny2/Manifest/DestinyActivityDefinition/{actes.activityHash}/"));
                            DestinyPublicMilestoneChallengeActivity d = jObject["Response"].ToObject<DestinyPublicMilestoneChallengeActivity>();
                            actes.displayProperties = d.displayProperties;
                            actes.pgcrImage = d.pgcrImage;
                            if (actes.modifierHashes != null)
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
                    if (temp.availableQuests != null)
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

        private void MilestoneObjectToDB(DestinyPublicMilestone milestone, ApplicationContext context)
        {
            Milestone milestoneDB = new Milestone()
            {
                Hash = milestone.milestoneHash,
                StartDate = milestone.startDate,
                EndDate = milestone.endDate
            };
            if (milestone.displayProperties != null)
            {
                milestoneDB.description = milestone.displayProperties.description;
                milestoneDB.name = milestone.displayProperties.name;
            }
            if (milestone.vendors != null)
            {
                foreach (var vendor in milestone.vendors)
                {
                    milestoneDB.VendorHash = vendor.vendorHash;
                }
            }
            if (milestone.availableQuests != null)
            {
                foreach (var quests in milestone.availableQuests)
                {
                    milestoneDB.QuestItemHash = quests.questItemHash;
                }
            }
            ActivityObjectToDB(milestoneDB, milestone);
            context.Milestones.Add(milestoneDB);
            context.SaveChanges();

        }
        private bool ActivityObjectToDB(Milestone milestoneDB, DestinyPublicMilestone milestone)
        {
            if (milestone.activities != null)
            {
                List<Activity> activities = new List<Activity>();
                foreach (var activity in milestone.activities)
                {
                    Activity activityTemp = new Activity
                    {
                        ActivityHash = activity.activityHash,
                        name = activity.displayProperties.name,
                        description = activity.displayProperties.description,
                        icon = activity.displayProperties.icon,
                    };
                    if (activity.pgcrImage != null & milestoneDB.ImageUrl == null)
                    {
                        milestoneDB.ImageUrl = activity.pgcrImage;
                    }
                    ModifiersObjectToDB(activity, activityTemp);
                    activities.Add(activityTemp);
                }
                milestoneDB.Activities = activities;
                return true;
            }
            else return false;
        }
        private bool ModifiersObjectToDB(DestinyPublicMilestoneChallengeActivity activity, Activity activityDB)
        {
            if (activity.modifiers != null)
            {
                List<Modifier> modifiers = new List<Modifier>();
                foreach (var mod in activity.modifiers)
                {
                    modifiers.Add(new Modifier
                    {
                        name = mod.displayProperties.name,
                        description = mod.displayProperties.description,
                        ModifierHash = mod.modifierHashes,
                        icon = mod.displayProperties.icon
                    });
                }

                activityDB.Modifiers = modifiers;
                return true;
            }
            else return false;
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    httpClient.Dispose();
                    destinyPublics = null;
                }
            }
            //dispose unmanaged resources
            disposed = true;
        }
    }
}
