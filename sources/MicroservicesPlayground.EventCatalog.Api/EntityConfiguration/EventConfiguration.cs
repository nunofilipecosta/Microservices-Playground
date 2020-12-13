using MicroservicesPlayground.EventCatalog.Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MicroservicesPlayground.EventCatalog.Api.EntityConfiguration
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.HasKey(e => e.EventId);
            builder.Property(e => e.EventId).IsRequired();
            builder.Property(e => e.Name).IsRequired();

            builder.HasOne(e => e.Category)
                .WithMany(c => c.Events);
        }
    }
}
