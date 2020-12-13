using System;
using System.Collections.Generic;

namespace MicroservicesPlayground.EventCatalog.Api.Entities
{
    public class Category
    {
        public Guid CategoryId { get; set; }

        public string Name { get; set; }

        public List<Event> Events { get; set; }
    }
}