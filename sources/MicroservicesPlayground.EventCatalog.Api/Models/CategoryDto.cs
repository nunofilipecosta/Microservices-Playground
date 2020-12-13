using System;

namespace MicroservicesPlayground.EventCatalog.Api.Models
{
    public class CategoryDto
    {
        public Guid CategoryId { get; set; }

        public string Name { get; set; }
    }
}