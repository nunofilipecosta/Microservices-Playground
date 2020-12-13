using MicroservicePlayground.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroservicePlayground.Web.Services
{
    public interface IEventCatalogService
    {
        Task<List<Event>> GetAll();

        Task<List<Event>> GetByCategoryId(Guid categoryid);

        Task<Event> GetEvent(Guid id);

        Task<List<Category>> GetCategories();
    }
}
