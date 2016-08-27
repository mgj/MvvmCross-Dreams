using Dreams.Core.Services.DreamsFetcher.Entities;
using System;
using System.Threading.Tasks;

namespace Dreams.Core.Services.DreamsFetcher
{
    public interface IDreamsFetcherService
    {
        Task<UrlCacheInfo> Fetch(Uri url);
        Task<UrlCacheInfo> Fetch(Uri url, long freshnessTreshold);
    }
}
