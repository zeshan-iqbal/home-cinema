using HomeCinema.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeCinema.Data.Mappings
{
    class RoleMap : EntityBaseConfigurationMap<Role>
    {
        public override void Configure(EntityTypeBuilder<Role> builder)
        {
            base.Configure(builder);

            builder.ToTable("Role");
            builder.Property(ur => ur.Name)
                .IsRequired()
                .HasMaxLength(50);

            ConfigureAduitable(builder);
        }
    }
}
