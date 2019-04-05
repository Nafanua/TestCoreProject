namespace TestApp.DataAccess.Models
{
    public class SiteDbo
    {
        public int Id { get; set; }

        public long TaskId { get; set; }

        public string Status { get; set; }

        public string PostId { get; set; }

        public string PostSite { get; set; }

        public string PostKey { get; set; }

        public int SearchEngineId { get; set; }

        public int LocationId { get; set; }

        public int KeyId { get; set; }
    }
}
