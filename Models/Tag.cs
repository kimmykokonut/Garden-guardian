using System.ComponentModel.DataAnnotations;

namespace GardenApi.Models
{
  public class Tag
  {
    public int TagId { get; set; }
    [Required]
    [StringLength(100)]
    public string NameTag { get; set; }
    //public List<SeedTag> SeedTags { get; }
  }
}