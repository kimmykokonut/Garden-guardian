using Microsoft.AspNetCore.Mvc;
using GardenApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GardenApi.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class GardensController : ControllerBase
  {
    private readonly GardenApiContext _db;

    public GardensController(GardenApiContext db)
    {
      _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Garden>>> Get(string name)
    {
      var query = _db.Gardens.AsQueryable();

      if (name != null)
      {
        query = query.Where(entry => entry.Name.Contains(name));
      }
      return await query.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Garden>> GetGarden(int id)
    {
      Garden thisgarden = await _db.Gardens
        .Include(garden => garden.Grids)
        .FirstOrDefaultAsync(garden => garden.GardenId == id);
      if (thisgarden == null)
      {
        return NotFound();
      }
      return thisgarden;
    }

    [HttpPost] //create garden & corr.grid
    public async Task<ActionResult<Garden>> Post(Garden garden)
    {
      _db.Gardens.Add(garden);

      // garden.Grids = new List<List<Grid>>(); //initialize grid layout
      for (int i = 0; i < garden.Row; i++)
      {
        //var row = new List<Grid>();
        for (int j = 0; j < garden.Column; j++)
        {
          var grid = new Grid { LocationCode = $"{i + 1}{(char)('A' + j)}", GardenId = garden.GardenId };
          _db.Grids.Add(grid);
          garden.Grids.Add(grid);
        }

      }

      await _db.SaveChangesAsync();
      return CreatedAtAction(nameof(GetGarden), new { id = garden.GardenId }, garden);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Garden garden)
    {
      if (id != garden.GardenId)
      {
        return BadRequest();
      }
      _db.Gardens.Update(garden);
      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!GardenExists(id))
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

    private bool GardenExists(int id)
    {
      return _db.Gardens.Any(e => e.GardenId == id);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteGarden(int id)
    {
      Garden garden = await _db.Gardens.FindAsync(id);
      if (garden == null)
      {
        return NotFound();
      }
      _db.Gardens.Remove(garden);
      await _db.SaveChangesAsync();
      return NoContent();
    }
  }
}