using MicroservicesPlayground.EventCatalog.Api.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroservicesPlayground.EventCatalog.Api.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllCategories();

        Task<Category> GetCategoryById(string categoryId);
    }
}