using System.Text.Json;

using Microsoft.Extensions.Options;

using RestSharp;

using SampleService.Models;

namespace SampleService.Services
{

    public class ApiClient : IApiClient
    {
        private readonly ServiceSettings _settings;

        public ApiClient(IOptions<ServiceSettings> settings)
        {
            _settings = settings.Value;
        }


        public CoinsInfo ConnectToApi(string currency)
        {
            var client = new RestClient($"{_settings.CoinsPriceUrl}/ticker");
            var request = new RestRequest(Method.GET);
            request.RequestFormat = DataFormat.Json;

            request.AddParameter("key", _settings.ApiKey, ParameterType.GetOrPost);
            request.AddParameter("label", "ethbtc-ltcbtc-BTCBTC-eosbtc", ParameterType.GetOrPost);
            request.AddParameter("fiat", currency, ParameterType.GetOrPost);

            var response = client.Get(request);

            var markets = JsonSerializer.Deserialize<CoinsInfo>(response.Content);

            return markets;

        }
    }

    public record Market(string Label, string Name, double Price);
    public record CoinsInfo(Market[] Markets);
}
