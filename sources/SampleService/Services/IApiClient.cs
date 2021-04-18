using SampleService.Models;

namespace SampleService.Services
{
    public interface IApiClient
    {
        CoinsInfo ConnectToApi(string currency);
    }
}
