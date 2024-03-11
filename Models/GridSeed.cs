namespace GardenApi.Models;

public class GridSeed
{
  public int GridSeedId { get; set; }
  public int GridId { get; set; }
  public Grid Grid { get; set; }
  public int SeedId { get; set; }
  public Seed Seed { get; set; }
}