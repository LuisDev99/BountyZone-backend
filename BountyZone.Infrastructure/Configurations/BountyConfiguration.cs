using BountyZone.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BountyZone.Infrastructure.Configurations
{
    public class BountyConfiguration : IEntityTypeConfiguration<Bounty>
    {
        public void Configure(EntityTypeBuilder<Bounty> builder)
        {
            builder.HasKey(x => x.ID);

            builder.Property(x => x.ID).ValueGeneratedOnAdd();

            builder.Property(x => x.HunterID).IsRequired(false);
        }
    }
}
