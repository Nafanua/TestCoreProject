using Newtonsoft.Json;

namespace TestApp.BusinessLogic.Models
{
    public class SearchEngineModel
    {
        [JsonProperty("se_id")]
        public int Id { get; set; }

        [JsonProperty("se_name")]
        public string Name { get; set; }

        [JsonProperty("se_country_iso_code")]
        public string CountryIsoCode { get; set; }

        [JsonProperty("se_country_name")]
        public string CountryName { get; set; }

        [JsonProperty("se_language")]
        public string Language { get; set; }

        [JsonProperty("se_localization")]
        public string Localization { get; set; }
    }
}
