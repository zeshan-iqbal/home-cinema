using HomeCinema.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeCinema.Data.Mappings
{
    class CustomerMap: EntityBaseConfigurationMap<Customer>
    {
        public override void Configure(EntityTypeBuilder<Customer> builder)
        {
            base.Configure(builder);

            builder.ToTable("Customer");

            builder.Property(u => u.FirstName).IsRequired().HasMaxLength(100);
            builder.Property(u => u.LastName).IsRequired().HasMaxLength(100);
            builder.Property(u => u.IdentityCard).IsRequired().HasMaxLength(50);
            builder.Property(u => u.UniqueKey).IsRequired();
            builder.Property(c => c.Mobile).HasMaxLength(10);
            builder.Property(c => c.Email).IsRequired().HasMaxLength(200);
            builder.Property(c => c.DateOfBirth).IsRequired();

            builder.HasMany(c => c.Rentals)
                .WithOne()
                .HasForeignKey(r => r.CustomerId);
        }
    }
}
