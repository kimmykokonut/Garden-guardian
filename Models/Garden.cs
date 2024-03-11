using System.ComponentModel.DataAnnotations;

namespace GardenApi.Models
{
  public class Garden
  {
    public int GardenId { get; set; }
    [Required(ErrorMessage = "Name is required")]
    [StringLength(90)]
    public string Name { get; set; }
    public string Size { get; set; }
    public int GridQty { get; set; }
    // public List<Grid> Grids { get; set; }
  }
}