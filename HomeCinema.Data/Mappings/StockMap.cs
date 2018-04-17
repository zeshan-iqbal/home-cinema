using HomeCinema.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeCinema.Data.Mappings
{
    class StockMap: EntityBaseConfigurationMap<Stock>
    {
        public override void Configure(EntityTypeBuilder<Stock> builder)
        {
            base.Configure(builder);
            builder.ToTable("Stock");

            builder.Property(s => s.MovieId).IsRequired();
            builder.Property(s => s.UniqueKey).IsRequired();
            builder.Property(s => s.IsAvailable).IsRequired();

            builder.HasMany(s => s.Rentals)
                .WithOne(r => r.Stock)
                .HasForeignKey(r => r.StockId);
        }
    }
}
