using Newtonsoft.Json;

namespace TestApp.BusinessLogic.Models
{
    public class LocationModel
    {
        [JsonProperty("loc_id")]
        public int Id { get; set; }

        [JsonProperty("loc_id_parent")]
        public int? ParentId { get; set; }

        [JsonProperty("loc_name")]
        public string Name { get; set; }

        [JsonProperty("loc_name_canonical")]
        public string CanonicalName { get; set; }

        [JsonProperty("loc_type")]
        public string Type { get; set; }

        [JsonProperty("loc_country_iso_code")]
        public string CountryIsoCode { get; set; }

        [JsonProperty("dma_region")]
        public bool DmaRegion { get; set; }

        [JsonProperty("kwrd_finder")]
        public bool KeywordFinder { get; set; }

        [JsonProperty("kwrd_finder_lang")]
        public string KeywordFinderLang { get; set; }
    }
}
