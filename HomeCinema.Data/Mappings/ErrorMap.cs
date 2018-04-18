using HomeCinema.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeCinema.Data.Mappings
{
    class ErrorMap: EntityBaseConfigurationMap<Error>
    {
        public override void Configure(EntityTypeBuilder<Error> builder)
        {
            base.Configure(builder);

            builder.ToTable("Error");

            builder.Property(p => p.Message);
            builder.Property(p => p.StackTrace);

            ConfigureAduitable(builder);
        }
    }
}
