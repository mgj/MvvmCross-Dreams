using Dreams.Core.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Dreams.Core.Services.DreamsLog;
using artm.MvxPlugins.Fetcher.Services;

namespace Dreams.Core.Services.DreamsWeb
{
    public class DreamsWebService : IDreamsWebService
    {
        private readonly IDreamsLogService _log;
        private readonly IFetcherService _fetcher;

        public DreamsWebService(IDreamsLogService logService, IFetcherService fetcher)
        {
            _log = logService;
            _fetcher = fetcher;
        }

        public async Task<List<DreamsWebServiceDTO>> FetchAsync()
        {
            var response = await _fetcher.Fetch(new Uri(DreamsSettings.DREAMSWEBSERVICE_BASE_URL));
            return await DreamsWebServiceDataFactory(response.Response);
        }

        private async Task<List<DreamsWebServiceDTO>> DreamsWebServiceDataFactory(string input)
        {
            var result = new List<DreamsWebServiceDTO>();
            try
            {
                result = await Task.Run(() => JsonConvert.DeserializeObject<List<DreamsWebServiceDTO>>(input));
            }
            catch (JsonException je)
            {
                _log.Log("Failed to deserialize", DreamsLogSeverityLevel.Error, je);
            }

            return result;
        }
    }
}
