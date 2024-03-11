using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GardenApi.Models;
using System.Linq;

namespace GardenApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class TagsController : ControllerBase
  {
    private readonly GardenApiContext _db;

    public TagsController(GardenApiContext db)
    {
      _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Tag>>> Get(string nametag)
    {
      var query = _db.Tags.AsQueryable();

      if (nametag != null)
      {
        query = query.Where(entry => entry.NameTag == nametag);

      }
      return await query.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Tag>> GetTag(int id)
    {
      Tag thisTag = await _db.Tags
      .Include(tag => tag.SeedTags)
      .ThenInclude(join => join.Seed)
      .FirstOrDefaultAsync(tag => tag.TagId == id);
      if (thisTag == null)
      {
        return NotFound();
      }
      return thisTag;
    }

    //create tag
    [HttpPost]
    public async Task<ActionResult<Tag>> Post(Tag tag)
    {
      _db.Tags.Add(tag);
      await _db.SaveChangesAsync();
      return CreatedAtAction(nameof(GetTag), new { id = tag.TagId }, tag);
    }

    //update/edit tag
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Tag tag)
    {
      if (id != tag.TagId)
      {
        return BadRequest();
      }
      _db.Tags.Update(tag);
      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!TagExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return NoContent();
    }

    private bool TagExists(int id)
    {
      return _db.Tags.Any(e => e.TagId == id);
    }

    //delete tag
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTag(int id)
    {
      Tag thisTag = await _db.Tags.FindAsync(id);
      if (thisTag == null)
      {
        return NotFound();
      }

      _db.Tags.Remove(thisTag);
      await _db.SaveChangesAsync();
      return NoContent();
    }

    [HttpPost("AddSeed")] //addseed JE to tag
    public async Task<IActionResult> AddSeed(Tag tag, int seedId)
    {
#nullable enable
      SeedTag? joinEnt = await _db.SeedTags.FirstOrDefaultAsync(join => (join.SeedId == seedId && join.TagId == tag.TagId));
#nullable disable
      if (joinEnt == null && seedId != 0)
      {
        _db.SeedTags.Add(new SeedTag() { SeedId = seedId, TagId = tag.TagId });
        await _db.SaveChangesAsync();
      }
      return NoContent();
    }
   }
}