using System;
using System.Collections.Generic;

namespace MicroservicePlayground.Web.Models
{
    public class EventListViewModel
    {
        public IEnumerable<Event> Events { get; set; }
        public Guid SelectedCategory { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public int NumberOfItems { get; set; }

        public EventListViewModel()
        {
        }
    }
}