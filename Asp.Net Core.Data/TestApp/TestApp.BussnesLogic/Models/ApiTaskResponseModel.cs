using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TestApp.BusinessLogic.Models
{
    class ApiTaskResponseModel
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("error")]
        public Error Error { get; set; }

        [JsonProperty("results_time")]
        public string ResultsTime { get; set; }

        [JsonProperty("results_count")]
        public string ResultsCount { get; set; }

        [JsonProperty("results")]
        public virtual SiteTask Results { get; set; }
    }
}
