using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace TestApp.BusinessLogic.Models
{
    public class SiteTask
    {
        [JsonProperty("organic")]
        public IList<STask> Organic { get; set; }

        [JsonProperty("paid")]
        public IList<STask> Paid { get; set; }
    }

    public class STask
    {
        [JsonProperty("post_id")]
        public string PostId { get; set; }

        [JsonProperty("post_site")]
        public string PostSite { get; set; }

        [JsonProperty("post_key")]
        public string PostKey { get; set; }

        [JsonProperty("se_id")]
        public int SearchEngineId { get; set; }

        [JsonProperty("loc_id")]
        public int LocationId { get; set; }

        [JsonProperty("key_id")]
        public int KeywordId { get; set; }

        [JsonProperty("result_position")]
        public int? ResultPosition { get; set; }

        [JsonProperty("task_id")]
        public long TaskId { get; set; }
    }
}
