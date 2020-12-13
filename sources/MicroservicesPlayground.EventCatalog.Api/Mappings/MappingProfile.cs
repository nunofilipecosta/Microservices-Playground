using AutoMapper;
using MicroservicesPlayground.EventCatalog.Api.Entities;
using MicroservicesPlayground.EventCatalog.Api.Models;

namespace MicroservicesPlayground.EventCatalog.Api.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();

            CreateMap<Event, EventDto>()
                .ForMember(dest => dest.CategoryName, opts => opts.MapFrom(src => src.Category.Name));
        }
    }
}
