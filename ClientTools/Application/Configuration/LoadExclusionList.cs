using System;
using System.Collections.Generic;
using System.IO;
using Domain.Entities;
using Newtonsoft.Json;

namespace Application.Configuration

{
    static class LoadExclusionList
    {
        public static List<PartSummary> LoadJson()
        {
            using (StreamReader r = new StreamReader(@".\Exclusions.json"))
            {
                string json = r.ReadToEnd();
                List<PartSummary> items = JsonConvert.DeserializeObject<List<PartSummary>>(json);
                return items;
            }
        }
    }
}
