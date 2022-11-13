﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using gamesDz;

#nullable disable

namespace gamesDz.Migrations
{
    [DbContext(typeof(GamesContext))]
    [Migration("20221113044441_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("gamesDz.Games", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Creator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlayStyle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RealiseDate")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("games");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Creator = "Blizzard",
                            Name = "Overwatch",
                            PlayStyle = "Shooter",
                            RealiseDate = 2016
                        },
                        new
                        {
                            Id = 2,
                            Creator = "Blizzard",
                            Name = "WoW",
                            PlayStyle = "MM",
                            RealiseDate = 2002
                        },
                        new
                        {
                            Id = 3,
                            Creator = "Ubisoft",
                            Name = "For Honor",
                            PlayStyle = "CCC",
                            RealiseDate = 2017
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
