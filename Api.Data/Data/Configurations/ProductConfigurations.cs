using Api.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Data.Configurations
{
    public class ProductConfigurations : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasOne(P => P.Type)
                .WithMany()
                .HasForeignKey(P => P.TypeId);


            builder.HasOne(P => P.Brand)
                .WithMany()
                .HasForeignKey(P => P.BrandId);

            builder.Property(P => P.Name).IsRequired()
                .HasMaxLength(100);

            builder.Property(P => P.Description).IsRequired();

            builder.Property(P => P.PictureUrl).IsRequired();
        }
    }
}
