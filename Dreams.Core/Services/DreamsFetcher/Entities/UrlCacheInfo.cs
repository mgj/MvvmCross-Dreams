using Realms;

namespace Dreams.Core.Services.DreamsFetcher.Entities
{
    public class UrlCacheInfo : RealmObject
    {
        public string Response { get; set; }

        [Indexed]
        public string Url { get; set; }

        public long Created { get; set; }

        public long LastAccessed { get; set; }

        public long LastUpdated { get; set; }
    }
}
