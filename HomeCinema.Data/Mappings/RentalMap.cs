using HomeCinema.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeCinema.Data.Mappings
{
    class RentalMap: EntityBaseConfigurationMap<Rental>
    {
        public override void Configure(EntityTypeBuilder<Rental> builder)
        {
            base.Configure(builder);

            builder.ToTable("Rental");

            builder.Property(r => r.CustomerId).IsRequired();
            builder.Property(r => r.StockId).IsRequired();
            builder.Property(r => r.Status).IsRequired().HasMaxLength(10);
            builder.Property(r => r.ReturnedDate).IsRequired(false);
        }
    }
}
