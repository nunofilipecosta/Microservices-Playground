using MicroservicesPlayground.EventCatalog.Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MicroservicesPlayground.EventCatalog.Api.EntityConfiguration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.CategoryId);
            builder.Property(c => c.CategoryId).IsRequired();
            builder.Property(c => c.Name).IsRequired();

            builder.HasMany(c => c.Events)
                .WithOne(e => e.Category);
        }
    }
}
