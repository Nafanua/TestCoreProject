using Newtonsoft.Json;

namespace TestApp.BusinessLogic.Models
{
    public class TaskResponse
    {
        [JsonProperty("task_id")]
        public long TaskId { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("error")]
        public Error Error { get; set; }

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
        public int KeyId { get; set; }
    }
}
