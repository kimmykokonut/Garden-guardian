namespace GardenApi.Models
{
  public class SeedTag
  {
    public int SeedTagId { get; set; }
    public int TagId { get; set; }
    public Tag Tag { get; set; }
    public int SeedId { get; set; }
    public Seed Seed { get; set; }

  }
}