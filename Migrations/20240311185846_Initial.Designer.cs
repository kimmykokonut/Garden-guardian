﻿// <auto-generated />
using GardenApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GardenGuardian.Migrations
{
    [DbContext(typeof(GardenApiContext))]
    [Migration("20240311185846_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("GardenApi.Models.Seed", b =>
                {
                    b.Property<int>("SeedId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("SeedId"));

                    b.Property<string>("DatePlanted")
                        .HasColumnType("text");

                    b.Property<string>("DaysToGerminate")
                        .HasColumnType("text");

                    b.Property<int>("DaysToHarvest")
                        .HasColumnType("integer");

                    b.Property<string>("DepthToSow")
                        .HasColumnType("text");

                    b.Property<string>("Information")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("PhotoUrl")
                        .HasColumnType("text");

                    b.Property<string>("PlantingDates")
                        .HasColumnType("text");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<string>("Results")
                        .HasColumnType("text");

                    b.Property<string>("RowSpacing")
                        .HasColumnType("text");

                    b.Property<string>("SeedSpacing")
                        .HasColumnType("text");

                    b.Property<string>("Status")
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .HasColumnType("text");

                    b.Property<int>("Yield")
                        .HasColumnType("integer");

                    b.HasKey("SeedId");

                    b.ToTable("Seeds");

                    b.HasData(
                        new
                        {
                            SeedId = 1,
                            DatePlanted = "2-14-2024",
                            DaysToGerminate = "5-10",
                            DaysToHarvest = 45,
                            DepthToSow = "1/4-1/2 in",
                            Information = "The Hakurei Turnip (a.k.a Tokyo Turnip) variety is usually stark white and has an unmatched crispness and tender sweetness. This turnip is commonly eaten raw which has led to it being given the nickname of 'Salad Turnip'.",
                            Name = "Hakurei Turnip",
                            PhotoUrl = "https://cdn.mos.cms.futurecdn.net/HMr9ceyW7Sc2kuz2S3dNF5.jpg",
                            PlantingDates = "spring, fall, winter",
                            Quantity = 10,
                            Results = "n/a",
                            RowSpacing = "12-24in",
                            SeedSpacing = "2 in",
                            Status = "planted",
                            Type = "vegetable",
                            Yield = 5
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
