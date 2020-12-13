using MicroservicePlayground.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroservicePlayground.Web.Services
{
    public class EventCatalogService : IEventCatalogService
    {
        private readonly List<Category> categories;
        private readonly List<Event> events;

        public EventCatalogService()
        {
            this.categories = new List<Category>();
            this.categories.Add(new Category { CategoryId = Guid.NewGuid(), Name = "Category 1" });
            this.categories.Add(new Category { CategoryId = Guid.NewGuid(), Name = "Category 2" });


            this.events = new List<Event>();
            this.events.Add(new Event { EventId = Guid.NewGuid(), Name = "Event 1", Description = "Description 1", Price = 1, ImageUrl = "https://picsum.photos/seed/picsum/100", CategoryId = this.categories[0].CategoryId });
            this.events.Add(new Event { EventId = Guid.NewGuid(), Name = "Event 2", Description = "Description 2", Price = 2, ImageUrl = "https://picsum.photos/seed/picsum/200", CategoryId = this.categories[0].CategoryId });
            this.events.Add(new Event { EventId = Guid.NewGuid(), Name = "Event 3", Description = "Description 3", Price = 3, ImageUrl = "https://picsum.photos/seed/picsum/250", CategoryId = this.categories[1].CategoryId });
            this.events.Add(new Event { EventId = Guid.NewGuid(), Name = "Event 4", Description = "Description 4", Price = 4, ImageUrl = "https://picsum.photos/seed/picsum/300", CategoryId = this.categories[1].CategoryId });
        }


        public Task<List<Event>> GetAll()
        {
            return Task.FromResult(events);
        }

        public async Task<List<Event>> GetByCategoryId(Guid categoryid)
        {
            return await Task.FromResult(this.events.Where(e => e.CategoryId == categoryid).ToList());
        }

        public async Task<List<Category>> GetCategories()
        {
            return await Task.FromResult(this.categories);
        }

        public async Task<Event> GetEvent(Guid id)
        {
            return await Task.FromResult(this.events.Where(e => e.EventId == id).SingleOrDefault());
        }
    }
}
