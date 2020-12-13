using MicroservicePlayground.Web.Models;
using MicroservicePlayground.Web.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MicroservicePlayground.Web.Controllers
{
    public class EventCatalogController : Controller
    {
        private readonly IEventCatalogService eventCatalogService;

        public EventCatalogController(IEventCatalogService eventCatalogService)
        {
            this.eventCatalogService = eventCatalogService;
        }

        public async Task<IActionResult> Index(Guid categoryId)
        {

            var getCategories = eventCatalogService.GetCategories();
            var getEvents = categoryId == Guid.Empty ? eventCatalogService.GetAll() : eventCatalogService.GetByCategoryId(categoryId);

            await Task.WhenAll(new Task[] { getCategories, getEvents });

            var viewModel = new EventListViewModel()
            {
                Categories = getCategories.Result,
                Events = getEvents.Result,
                NumberOfItems = 0,
                SelectedCategory = categoryId
            };

            return View(viewModel);
        }


        [HttpPost]
        public IActionResult Filter([FromForm] Guid selectedCategory)
        {
            return RedirectToAction("Index", new { categoryId = selectedCategory });
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid eventId)
        {
            var viewModel = await this.eventCatalogService.GetEvent(eventId);
            return View(viewModel);
        }
    }

}
