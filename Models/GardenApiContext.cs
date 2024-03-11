using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;

namespace GardenApi.Models
{
  public class GardenApiContext : DbContext
  {
    // public DbSet<Garden> Gardens { get; set; }
    // public DbSet<Grid> Grids { get; set; }
    public DbSet<Seed> Seeds { get; set; }
    // public DbSet<Tag> Tags { get; set; }
    // public DbSet<GridSeed> GridSeeds { get; set; }
    // public DbSet<SeedTag> SeedTags { get; set; }
    // public DbSet<ApplicationUser> Users { get; set; }
    // public DbSet<IdentityUserClaim<string>> UserClaims { get; set; }

    public GardenApiContext(DbContextOptions<GardenApiContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);

      // builder.Entity<SeedTag>()
      //     .HasKey(st => new { st.SeedTagId });

      // builder.Entity<SeedTag>()
      //     .HasOne(s => s.Seed)
      //     .WithMany(st => st.SeedTags)
      //     .HasForeignKey(s => s.SeedId);

      // builder.Entity<SeedTag>()
      //     .HasOne(t => t.Tag)
      //     .WithMany(st => st.SeedTags)
      //     .HasForeignKey(t => t.TagId);

      builder.Entity<Seed>()
          .HasData(
              new Seed
              {
                SeedId = 1,
                Type = "vegetable",
                Name = "Hakurei Turnip",
                Quantity = 10,
                Information = "The Hakurei Turnip (a.k.a Tokyo Turnip) variety is usually stark white and has an unmatched crispness and tender sweetness. This turnip is commonly eaten raw which has led to it being given the nickname of 'Salad Turnip'.",
                PlantingDates = "spring, fall, winter",
                DaysToGerminate = "5-10",
                DepthToSow = "1/4-1/2 in",
                SeedSpacing = "2 in",
                RowSpacing = "12-24in",
                DaysToHarvest = 45,
                PhotoUrl = "https://cdn.mos.cms.futurecdn.net/HMr9ceyW7Sc2kuz2S3dNF5.jpg",
                Status = "planted",
                Results = "n/a",
                Yield = 5,
                DatePlanted = "2-14-2024"
              }
          );


    }
  }
}