using MicroservicePlayground.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace MicroservicePlayground.Web.Services
{
    public class HttpEventCatalogService : IEventCatalogService
    {
        private readonly HttpClient client;

        public HttpEventCatalogService(HttpClient client)
        {
            this.client = client;
        }

        public async Task<List<Event>> GetAll()
        {
            var response = await client.GetAsync("/api/events");
            if (!response.IsSuccessStatusCode)
                throw new ApplicationException($"Something went wrong calling the API: {response.ReasonPhrase}");

            var dataAsString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var result = JsonSerializer.Deserialize<List<Event>>(dataAsString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return result;
        }

        public async Task<List<Event>> GetByCategoryId(Guid categoryid)
        {
            var response = await client.GetAsync($"/api/events/?categoryId={categoryid}");
            if (!response.IsSuccessStatusCode)
                throw new ApplicationException($"Something went wrong calling the API: {response.ReasonPhrase}");
            var dataAsString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var result = JsonSerializer.Deserialize<List<Event>>(dataAsString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return result;
        }

        public async Task<List<Category>> GetCategories()
        {
            var response = await client.GetAsync("/api/categories");
            if (!response.IsSuccessStatusCode)
                throw new ApplicationException($"Something went wrong calling the API: {response.ReasonPhrase}");
            var dataAsString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var result = JsonSerializer.Deserialize<List<Category>>(dataAsString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return result;
        }

        public async Task<Event> GetEvent(Guid id)
        {
            var response = await client.GetAsync($"/api/events/{id}");
            if (!response.IsSuccessStatusCode)
                throw new ApplicationException($"Something went wrong calling the API: {response.ReasonPhrase}");
            var dataAsString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var result = JsonSerializer.Deserialize<Event>(dataAsString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return result;
        }
    }
}
