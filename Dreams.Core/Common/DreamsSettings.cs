using Polly;
using Polly.Retry;
using System;
using System.Net.Http;

namespace Dreams.Core.Common
{
    public static class DreamsSettings
    {
        public const int NETWORK_RETRY_COUNTER = 5;
        public const string DREAMSWEBSERVICE_BASE_URL = "https://jsonplaceholder.typicode.com/users";

        public static readonly RetryPolicy<HttpResponseMessage> NETWORK_DEFAULT_POLICY = Policy
                .HandleResult<HttpResponseMessage>(r => r.IsSuccessStatusCode == false)
                .WaitAndRetryAsync(NETWORK_RETRY_COUNTER, retryAttempt =>
                    TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
    }
}
