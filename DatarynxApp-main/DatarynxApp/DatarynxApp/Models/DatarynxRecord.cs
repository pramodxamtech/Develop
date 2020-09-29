using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DatarynxApp.Models
{
    [Serializable]
    public class DatarynxRecord:BaseItem
    {
        [JsonProperty("week-no")]
        public string WeekNo { get; set; }

        [JsonProperty("week-date")]
        public string WeekDate { get; set; }

        [JsonProperty("store-name")]
        public string StoreName { get; set; }

        [JsonProperty("store-address")]
        public string StoreAddress { get; set; }

        [JsonProperty("coding-type")]
        public string CodingType { get; set; }

        [JsonProperty("Task-State")]
        public string TaskState { get; set; }
        public bool IsVisible { get; set; }
        public string Image { get; set; }
    }

    [Serializable]
    public class RootObject
    {
        List<DatarynxRecord> DatarynxRecords { get; set; }
    }
}
