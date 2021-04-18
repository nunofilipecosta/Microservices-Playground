using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using Polly;

using RestSharp;

using SampleService.Models;

namespace SampleService.Services
{

    public class ApiClient : IApiClient
    {
        private readonly ServiceSettings settings;
        private readonly ILogger<ApiClient> logger;
        private Policy<IRestResponse> retryPolicy;

        private static readonly List<HttpStatusCode> invalidStatusCodes = new List<HttpStatusCode> {
        HttpStatusCode.BadGateway,
        HttpStatusCode.Unauthorized,
        HttpStatusCode.InternalServerError,
        HttpStatusCode.RequestTimeout,
        HttpStatusCode.BadRequest,
        HttpStatusCode.Forbidden,
        HttpStatusCode.GatewayTimeout
    };

        public ApiClient(IOptions<ServiceSettings> settings, ILogger<ApiClient> logger)
        {
            this.settings = settings.Value;
            this.logger = logger;

            retryPolicy = Policy
                .HandleResult<IRestResponse>(resp => {
                    if (invalidStatusCodes.Contains(resp.StatusCode)) {
                        return true;
                    }

                    if (resp.StatusCode == HttpStatusCode.OK && resp.Content.Contains("err"))
                    {
                        return true;
                    }

                    return false;
                
                })
                .WaitAndRetry(6, i => TimeSpan.FromSeconds(Math.Pow(2, i)), (result, timeSpan, currentRetryCount, context) =>
                {
                    logger.LogError($"Request failed with {result.Result.StatusCode}. Waiting {timeSpan} before next retry. Retry attempt {currentRetryCount}.");
                });
        }


        public CoinsInfo ConnectToApi(string currency)
        {
            var client = new RestClient($"{settings.CoinsPriceUrl}/ticker");
            var request = new RestRequest(Method.GET);
            request.RequestFormat = DataFormat.Json;

            request.AddParameter("key", settings.ApiKey, ParameterType.GetOrPost);
            request.AddParameter("label", "ethbtc-ltcbtc-BTCBTC-eosbtc", ParameterType.GetOrPost);
            request.AddParameter("fiat", currency, ParameterType.GetOrPost);

            var policyResponse = retryPolicy.ExecuteAndCapture(() =>
            {
                var response = client.Get(request);
                return response;
            });

            if (policyResponse.Result != null)
            {
                var markets = JsonSerializer.Deserialize<CoinsInfo>(policyResponse.Result.Content);
                return markets;
            }

            return null;






        }
    }

    public record Market(string Label, string Name, double Price);
    public record CoinsInfo(Market[] Markets);
}
