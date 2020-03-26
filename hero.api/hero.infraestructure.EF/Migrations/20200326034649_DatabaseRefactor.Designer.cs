﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using hero.infraestructure.EF.Contexts;

namespace hero.infraestructure.EF.Migrations
{
    [DbContext(typeof(HeroDbContext))]
    [Migration("20200326034649_DatabaseRefactor")]
    partial class DatabaseRefactor
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("hero.domain.Entities.Hero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Alias");

                    b.Property<DateTime>("CreationDate");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("Range");

                    b.Property<int>("SenseiId");

                    b.HasKey("Id");

                    b.HasIndex("SenseiId");

                    b.ToTable("Heroes");
                });

            modelBuilder.Entity("hero.domain.Entities.HeroPower", b =>
                {
                    b.Property<int>("HeroId");

                    b.Property<int>("PowerId");

                    b.HasKey("HeroId", "PowerId");

                    b.HasIndex("PowerId");

                    b.ToTable("HeroPower");
                });

            modelBuilder.Entity("hero.domain.Entities.HeroTeam", b =>
                {
                    b.Property<int>("HeroId");

                    b.Property<int>("TeamId");

                    b.HasKey("HeroId", "TeamId");

                    b.HasIndex("TeamId");

                    b.ToTable("HeroTeam");
                });

            modelBuilder.Entity("hero.domain.Entities.Power", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationDate");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Power");
                });

            modelBuilder.Entity("hero.domain.Entities.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationDate");

                    b.Property<string>("Name");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.ToTable("Team");
                });

            modelBuilder.Entity("hero.domain.Entities.Hero", b =>
                {
                    b.HasOne("hero.domain.Entities.Hero", "Sensei")
                        .WithMany("Students")
                        .HasForeignKey("SenseiId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("hero.domain.Entities.HeroPower", b =>
                {
                    b.HasOne("hero.domain.Entities.Hero", "Hero")
                        .WithMany("Powers")
                        .HasForeignKey("HeroId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("hero.domain.Entities.Power", "Power")
                        .WithMany("Heroes")
                        .HasForeignKey("PowerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("hero.domain.Entities.HeroTeam", b =>
                {
                    b.HasOne("hero.domain.Entities.Hero", "Hero")
                        .WithMany("Teams")
                        .HasForeignKey("HeroId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("hero.domain.Entities.Team", "Team")
                        .WithMany("Members")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
