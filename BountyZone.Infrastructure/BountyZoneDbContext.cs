using BountyZone.Core.Entities;
using BountyZone.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BountyZone.Infrastructure
{
    public class BountyZoneDbContext : DbContext
    {
        public BountyZoneDbContext(DbContextOptions options) :
            base(options)
        {

        }

        public DbSet<Event> Events { get; set; }

        public DbSet<Bounty> Bounties { get; set; }

        public DbSet<Hunter> Hunters { get; set; }

        public DbSet<Leader> Leaders { get; set; }

        public DbSet<Player> Players { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BountyConfiguration());
            modelBuilder.ApplyConfiguration(new EventConfiguration());
            modelBuilder.ApplyConfiguration(new HunterConfiguration());
            modelBuilder.ApplyConfiguration(new LeaderConfiguration());
            modelBuilder.ApplyConfiguration(new PlayerConfiguration());
        }
    }
}
