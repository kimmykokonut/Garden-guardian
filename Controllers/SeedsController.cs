using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GardenApi.Models;

namespace GardenApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SeedsController : ControllerBase
{
  private readonly GardenApiContext _db;

  public SeedsController(GardenApiContext db)
  {
    _db = db;
  }
  [HttpGet]
  public async Task<ActionResult<IEnumerable<Seed>>> Get(string type, string name, string plantingDates, string status, string results, int yield)
  {
    IQueryable<Seed> q = _db.Seeds.AsQueryable();
    if (type != null)
    {
      q = q.Where(e => e.Type == type);
    }
    if (name != null)
    {
      q = q.Where(e => e.Name.Contains(name));
    }
    if (plantingDates != null)
    {
      q = q.Where(e => e.PlantingDates == plantingDates);
    }
    if (status != null)
    {
      q = q.Where(e => e.Status == status);
    }
    if (results != null)
    {
      q = q.Where(e => e.Results == results);
    }
    if (yield > 0)
    {
      q = q.Where(e => e.Yield == yield);
    }

    return await q.ToListAsync();
  }
  [HttpGet("{id}")]
  public async Task<ActionResult<Seed>> GetSeed(int id)
  {
    Seed foundSeed = await _db.Seeds
    .Include(seed => seed.SeedTags) //load JE prop of each seed (the List<SeedTag>)
    .ThenInclude(join => join.Tag) //actual item
    .FirstOrDefaultAsync(seed => seed.SeedId == id);
    if (foundSeed == null)
    {
      return NotFound();
    }
    return foundSeed;
  }
  [HttpPost]
  public async Task<ActionResult<Seed>> Post(Seed seed) //CREATE
  {
    _db.Seeds.Add(seed);
    await _db.SaveChangesAsync();
    return CreatedAtAction(nameof(GetSeed), new { id = seed.SeedId }, seed);
  }

  [HttpPut("{id}")] //EDIT
  public async Task<IActionResult> Put(int id, Seed seed)
  {
    if (id != seed.SeedId)
    {
      return BadRequest();
    }
    _db.Seeds.Update(seed);

    try
    {
      await _db.SaveChangesAsync();
    }
    catch (DbUpdateConcurrencyException)
    {
      if (!SeedExists(id))
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
  private bool SeedExists(int id)
  {
    return _db.Seeds.Any(e => e.SeedId == id);
  }
  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteSeed(int id)
  {
    Seed seedToDelete = await _db.Seeds.FindAsync(id);
    if (seedToDelete == null)
    {
      return NotFound();
    }
    _db.Seeds.Remove(seedToDelete);
    await _db.SaveChangesAsync();

    return NoContent();
  }

  [HttpPost("AddTag")] //addtag JE to seed
  public async Task<IActionResult> AddTag(Seed seed, int tagId)
  {
#nullable enable
    SeedTag? joinEnt = await _db.SeedTags.FirstOrDefaultAsync(join => join.TagId == tagId && join.SeedId == seed.SeedId);
#nullable disable
    if (joinEnt == null && tagId != 0)
    {
      _db.SeedTags.Add(new SeedTag() { TagId = tagId, SeedId = seed.SeedId });
      await _db.SaveChangesAsync();
    }
    return NoContent();
  }

}