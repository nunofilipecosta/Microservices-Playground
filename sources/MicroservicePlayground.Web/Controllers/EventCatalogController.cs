using MicroservicePlayground.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace MicroservicePlayground.Web.Controllers
{
    public class EventCatalogController : Controller
    {
        public IActionResult Index(Guid categoryId)
        {
            var viewModel = new EventListViewModel()
            {
                Categories = new List<Category>
                {
                    new Category { CategoryId = Guid.NewGuid(), Name = "Category 1" },
                    new Category { CategoryId = Guid.NewGuid(), Name = "Category 2" }
                },
                Events = new List<Event>
                {
                    new Event { EventId = Guid.NewGuid(), Name = "Event 1", Description = "Description 1", Price = 1, ImageUrl = "https://picsum.photos/seed/picsum/100"},
                    new Event { EventId = Guid.NewGuid(), Name = "Event 2", Description = "Description 2", Price = 2, ImageUrl = "https://picsum.photos/seed/picsum/200"},
                    new Event { EventId = Guid.NewGuid(), Name = "Event 3", Description = "Description 3", Price = 3, ImageUrl = "https://picsum.photos/seed/picsum/250"},
                    new Event { EventId = Guid.NewGuid(), Name = "Event 4", Description = "Description 4", Price = 4, ImageUrl = "https://picsum.photos/seed/picsum/300"},
                },
                NumberOfItems = 4,
                SelectedCategory = Guid.Empty
            };

            return View(viewModel);
        }


        [HttpPost]
        public IActionResult Filter([FromForm]Guid selectedCategory)
        {
            return RedirectToAction("Index", new { categoryId = selectedCategory });
        }
    }

}
