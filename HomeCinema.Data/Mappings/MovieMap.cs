using HomeCinema.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeCinema.Data.Mappings
{
    class MovieMap : EntityBaseConfigurationMap<Movie>
    {
        public override void Configure(EntityTypeBuilder<Movie> builder)
        {
            base.Configure(builder);

            builder.ToTable("Movie");
            builder.Property(m => m.GenreId).IsRequired();
            builder.Property(m => m.Title).IsRequired().HasMaxLength(100);
            builder.Property(m => m.Director).IsRequired().HasMaxLength(100);
            builder.Property(m => m.Writer).IsRequired().HasMaxLength(50);
            builder.Property(m => m.Producer).IsRequired().HasMaxLength(50);
            builder.Property(m => m.Writer).HasMaxLength(50);
            builder.Property(m => m.Producer).HasMaxLength(50);
            builder.Property(m => m.Rating).IsRequired();
            builder.Property(m => m.Description).IsRequired().HasMaxLength(2000);
            builder.Property(m => m.TrailerUrl).HasMaxLength(200);

            ConfigureAduitable(builder);

            builder.HasMany(m => m.Stocks)
                .WithOne()
                .HasForeignKey(s => s.MovieId);

            builder.HasOne(m => m.Genre)
                .WithMany(g => g.Movies)
                .HasForeignKey(m => m.GenreId);
        }
    }
}
