using HomeCinema.Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HomeCinema.Data.Mappings
{
    class EntityBaseConfigurationMap<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.CreatedBy).IsRequired();
            builder.Property(p => p.CreatedDate).HasDefaultValue(DateTime.UtcNow).IsRequired();

            builder.Property(p => p.LastModifiedBy).IsRequired(false);
            builder.Property(p => p.LastModifiedDate).IsRequired(false);

            builder.Property(p => p.Deleted).HasDefaultValue(false);
            builder.Ignore(p => p.IsNew);

        }
    }
}
