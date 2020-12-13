using MicroservicesPlayground.EventCatalog.Api.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroservicesPlayground.EventCatalog.Api.Repositories
{
    public interface IEventRepository
    {
        Task<IEnumerable<Event>> GetEvents(Guid categoryId);

        Task<Event> GetEventById(Guid eventId);
    }
}
