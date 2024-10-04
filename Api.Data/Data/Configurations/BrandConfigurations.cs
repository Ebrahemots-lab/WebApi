using Api.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Data.Data.Configurations
{
    public class BrandConfigurations : IEntityTypeConfiguration<ProductType>
    {
        public void Configure(EntityTypeBuilder<ProductType> builder)
        {
            builder.Property(T => T.Name).IsRequired().HasMaxLength(50);
        }
    }
}
