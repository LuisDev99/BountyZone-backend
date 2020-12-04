using BountyZone.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BountyZone.Infrastructure.Configurations
{
    public class LeaderConfiguration : IEntityTypeConfiguration<Leader>
    {
        public void Configure(EntityTypeBuilder<Leader> builder)
        {
            builder.HasKey(x => x.ID);

            builder.Property(x => x.ID).ValueGeneratedOnAdd();

            builder.Property(x => x.Money).HasDefaultValue(1000);

            builder.Property(x => x.Reputation).HasDefaultValue(0);

            builder.Property(x => x.SuccessfulAttacks).HasDefaultValue(0);

            builder.Property(x => x.SuccessfulAttacks).HasDefaultValue(0);
        }
    }
}
