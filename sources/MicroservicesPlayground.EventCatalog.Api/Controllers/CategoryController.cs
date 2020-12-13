using AutoMapper;
using MicroservicesPlayground.EventCatalog.Api.Models;
using MicroservicesPlayground.EventCatalog.Api.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroservicesPlayground.EventCatalog.Api.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryRepository _categoryRepository;
        private IMapper _mapper;

        public CategoryController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<CategoryDto>>> Get()
        {
            var result = await _categoryRepository.GetAllCategories();


            var result2 = _mapper.Map<List<CategoryDto>>(result);
            return Ok(result2);

        }
    }
}
