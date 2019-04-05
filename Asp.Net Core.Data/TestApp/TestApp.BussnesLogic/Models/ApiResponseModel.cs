using Newtonsoft.Json;
using System.Collections.Generic;
using TestApp.DataAccess.Models;

namespace TestApp.BusinessLogic.Models
{
    public class ApiResponseModel<T> where T : class 
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
        public virtual IList<T> Results { get; set; }
    }

    public class Error
    {
        [JsonProperty("code")]
        public int ErrorCode { get; set; }

        [JsonProperty("message")]
        public string ErrorMessage { get; set; }
    }
}
