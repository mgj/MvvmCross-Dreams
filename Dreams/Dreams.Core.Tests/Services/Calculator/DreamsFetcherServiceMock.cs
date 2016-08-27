using Dreams.Core.Services.DreamsFetcher;
using System;
using System.Threading.Tasks;
using Dreams.Core.Services.DreamsLog;

namespace Dreams.Core.Tests.Services.Calculator
{
    public class DreamsFetcherServiceMock : DreamsFetcherService
    {
        public DreamsFetcherServiceMock(IDreamsLogService logService) 
            : base(logService)
        {
        }

        public string FetchFromWebResponse
        {
            get;
            set;
        }

        protected override Task<string> FetchFromWeb(Uri uri)
        {
            return Task.FromResult(FetchFromWebResponse);
        }
    }
}
