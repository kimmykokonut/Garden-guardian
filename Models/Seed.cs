using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GardenApi.Models
{
  public class Seed
  {
    public int SeedId { get; set; }
    public string Type { get; set; }
    [Required]
    [StringLength(255)]
    public string Name { get; set; }
    [Required]
    public int Quantity { get; set; }
    public string Information { get; set; }
    public string PlantingDates { get; set; }
    public string DaysToGerminate { get; set; }
    public string DepthToSow { get; set; }
    public string SeedSpacing { get; set; }
    public string RowSpacing { get; set; }
    public int DaysToHarvest { get; set; }
    public string PhotoUrl { get; set; }
    [Required]
    [StringLength(100)]
    public string Status { get; set; }
    public string DatePlanted { get; set; }
    public string Results { get; set; }
    public int Yield { get; set; }
    public List<SeedTag> SeedTags { get; }
    // public List<GridSeed> GridSeeds { get; }
  }
}