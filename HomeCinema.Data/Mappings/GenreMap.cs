using HomeCinema.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeCinema.Data.Mappings
{
    class GenreMap : EntityBaseConfigurationMap<Genre>
    {
        public override void Configure(EntityTypeBuilder<Genre> builder)
        {
            base.Configure(builder);

            builder.ToTable("Genre");
            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(50);

            ConfigureAduitable(builder);

            builder.HasMany(p => p.Movies)
                .WithOne()
                .HasForeignKey(r => r.GenreId);
        }
    }
}
