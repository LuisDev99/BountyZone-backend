﻿// <auto-generated />
using System;
using BountyZone.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace BountyZone.Infrastructure.Migrations
{
    [DbContext(typeof(BountyZoneDbContext))]
    partial class BountyZoneDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("BountyZone.Core.Entities.Bounty", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<bool>("Bribed")
                        .HasColumnType("boolean");

                    b.Property<int?>("HunterID")
                        .HasColumnType("integer");

                    b.Property<bool>("IsConfirmed")
                        .HasColumnType("boolean");

                    b.Property<int>("LeaderID")
                        .HasColumnType("integer");

                    b.Property<int>("Price")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Time")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("VictimID")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("HunterID");

                    b.HasIndex("LeaderID");

                    b.HasIndex("VictimID");

                    b.ToTable("Bounties");
                });

            modelBuilder.Entity("BountyZone.Core.Entities.Event", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<int>("HunterID")
                        .HasColumnType("integer");

                    b.Property<int>("LeaderID")
                        .HasColumnType("integer");

                    b.Property<int>("VictimID")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("HunterID");

                    b.HasIndex("LeaderID");

                    b.HasIndex("VictimID");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("BountyZone.Core.Entities.Hunter", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<int>("Bribes")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0);

                    b.Property<int>("Guns")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0);

                    b.Property<int>("PlayerID")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("PlayerID");

                    b.ToTable("Hunters");
                });

            modelBuilder.Entity("BountyZone.Core.Entities.Leader", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<int>("Money")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(1000);

                    b.Property<int>("PlayerID")
                        .HasColumnType("integer");

                    b.Property<int>("Reputation")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0);

                    b.Property<int>("SuccessfulAttacks")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0);

                    b.Property<int>("SuccessfulDefends")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("PlayerID");

                    b.ToTable("Leaders");
                });

            modelBuilder.Entity("BountyZone.Core.Entities.Player", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("NickName")
                        .HasColumnType("text");

                    b.Property<int>("PlayerRoleID")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("PlayerRoleID");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("BountyZone.Core.Entities.PlayerRole", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("ImageURL")
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("PlayerRoles");
                });

            modelBuilder.Entity("BountyZone.Core.Entities.Bounty", b =>
                {
                    b.HasOne("BountyZone.Core.Entities.Hunter", "Hunter")
                        .WithMany()
                        .HasForeignKey("HunterID");

                    b.HasOne("BountyZone.Core.Entities.Leader", "Leader")
                        .WithMany()
                        .HasForeignKey("LeaderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BountyZone.Core.Entities.Leader", "Victim")
                        .WithMany()
                        .HasForeignKey("VictimID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hunter");

                    b.Navigation("Leader");

                    b.Navigation("Victim");
                });

            modelBuilder.Entity("BountyZone.Core.Entities.Event", b =>
                {
                    b.HasOne("BountyZone.Core.Entities.Hunter", "Hunter")
                        .WithMany()
                        .HasForeignKey("HunterID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BountyZone.Core.Entities.Leader", "Leader")
                        .WithMany()
                        .HasForeignKey("LeaderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BountyZone.Core.Entities.Leader", "Victim")
                        .WithMany()
                        .HasForeignKey("VictimID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hunter");

                    b.Navigation("Leader");

                    b.Navigation("Victim");
                });

            modelBuilder.Entity("BountyZone.Core.Entities.Hunter", b =>
                {
                    b.HasOne("BountyZone.Core.Entities.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Player");
                });

            modelBuilder.Entity("BountyZone.Core.Entities.Leader", b =>
                {
                    b.HasOne("BountyZone.Core.Entities.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Player");
                });

            modelBuilder.Entity("BountyZone.Core.Entities.Player", b =>
                {
                    b.HasOne("BountyZone.Core.Entities.PlayerRole", "PlayerRole")
                        .WithMany()
                        .HasForeignKey("PlayerRoleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PlayerRole");
                });
#pragma warning restore 612, 618
        }
    }
}
