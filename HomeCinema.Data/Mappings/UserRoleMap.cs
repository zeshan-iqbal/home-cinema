using HomeCinema.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeCinema.Data.Mappings
{
    class UserRoleMap: EntityBaseConfigurationMap<UserRole>
    {
        public override void Configure(EntityTypeBuilder<UserRole> builder)
        {
            base.Configure(builder);

            builder.ToTable("UserRole");
            builder.Property(ur => ur.UserId).IsRequired();
            builder.Property(ur => ur.RoleId).IsRequired();

            ConfigureAduitable(builder);
        }
    }
}
