using System.ComponentModel.DataAnnotations;

namespace GardenApi.Models
{
  public class Grid
  {
    public int GridId { get; set; }
    [Required]
    public string LocationCode { get; set; }
    public int GardenId { get; set; }
    public Garden Garden { get; set; }
    public List<GridSeed> GridSeeds { get; }
  }
}