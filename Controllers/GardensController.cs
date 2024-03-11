using Microsoft.AspNetCore.Mvc;
using GardenApi.Models;
using System.Collections.Generic;
using System.Linq;
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

    //GET api/gardens  same as index
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Garden>>> Get(string name, string size, int gridQty)
    {
      var query = _db.Gardens.AsQueryable();

      if (name != null)
      {
        query = query.Where(entry => entry.Name == name);
      }

      if (gridQty != 0)
      {
        query = query.Where(entry => entry.GridQty == gridQty);
      }

      return await query.ToListAsync();
    }

    //GET api/gardens/5 same as details
    [HttpGet("{id}")]
    public async Task<ActionResult<Garden>> GetGarden(int id)
    {
      Garden thisgarden = await _db.Gardens
        //.Include(garden => garden.Grids)
        .FirstOrDefaultAsync(garden => garden.GardenId == id);
      if (thisgarden == null)
      {
        return NotFound();
      }
      return thisgarden;

    }

    //POST api/gardens same as create
    [HttpPost]
    public async Task<ActionResult<Garden>> Post(Garden garden)
    {
      _db.Gardens.Add(garden);
      await _db.SaveChangesAsync();
      return CreatedAtAction(nameof(GetGarden), new { id = garden.GardenId }, garden);
    }

    //PUT api/gardens/5
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

    //`DELETE` api/gardens/5
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