using HomeCinema.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeCinema.Data.Mappings
{
    class UserMap: EntityBaseConfigurationMap<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);

            builder.ToTable("User");

            builder.Property(u => u.Username).IsRequired().HasMaxLength(100);
            builder.Property(u => u.Email).IsRequired().HasMaxLength(200);
            builder.Property(u => u.HashedPassword).IsRequired().HasMaxLength(200);
            builder.Property(u => u.Salt).IsRequired().HasMaxLength(200);
            builder.Property(u => u.IsLocked).IsRequired();

            ConfigureAduitable(builder);
        }
    }
}
