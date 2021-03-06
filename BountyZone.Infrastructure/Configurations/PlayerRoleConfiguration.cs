﻿using BountyZone.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BountyZone.Infrastructure.Configurations
{
    public class PlayerRoleConfiguration : IEntityTypeConfiguration<PlayerRole>
    {
        public void Configure(EntityTypeBuilder<PlayerRole> builder)
        {
            builder.HasKey(x => x.ID);

            builder.Property(x => x.ID).ValueGeneratedOnAdd();
        }
    }
}
