using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.eShopWeb.ApplicationCore.Entities;

namespace Microsoft.eShopWeb.Infrastructure.Data.Config
{
    //Added for the price filter
    public class CatalogPriceConfiguration : IEntityTypeConfiguration<CatalogPrice>
    {
        public void Configure(EntityTypeBuilder<CatalogPrice> builder)
        {
            builder.HasKey(ci => ci.Id);

            builder.Property(ci => ci.Id)
               .UseHiLo("catalog_price_hilo")
               .IsRequired();

            builder.Property(cb => cb.Price)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
