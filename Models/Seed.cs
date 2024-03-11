using System.Collections.Generic;

namespace GardenApi.Models
{
  public class Seed
  {
    public int SeedId { get; set; }
    public string Type { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
    public string Information { get; set; }
    public string PlantingDates { get; set; }
    public string DaysToGerminate { get; set; }
    public string DepthToSow { get; set; }
    public string SeedSpacing { get; set; }
    public string RowSpacing { get; set; }
    public int DaysToHarvest { get; set; }
    public string PhotoUrl { get; set; }
    public string Status { get; set; }
    public string DatePlanted { get; set; }
    public string Results { get; set; }
    public int Yield { get; set; }
    // public List<SeedTag> SeedTags { get; }
    // public List<GridSeed> GridSeeds { get; }
  }
}