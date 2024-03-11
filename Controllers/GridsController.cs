using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using GardenApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace GardenApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class GridsController : ControllerBase
  {
    private readonly GardenApiContext _db;

    public GridsController(GardenApiContext db)
    {
      _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Grid>>> GetGrids() //return a sequence of grids
    {
      return await _db.Grids.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Grid>> GetGrid(int id)
    {
      var grid = await _db.Grids
          //.Include(g => g.GridSeeds)
          //.ThenInclude(gs => gs.Seed)
          .FirstOrDefaultAsync(g => g.GridId == id);

      if (grid == null)
      {
        return NotFound();
      }

      return grid;
    }

    [HttpPost]
    public async Task<ActionResult<Grid>> PostGrid(Grid grid)
    {
      _db.Grids.Add(grid);
      await _db.SaveChangesAsync();

      return CreatedAtAction(nameof(GetGrid), new { id = grid.GridId }, grid);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutGrid(int id, Grid grid) //determines result of action
    {
      if (id != grid.GridId)
      {
        return BadRequest();
      }

      _db.Entry(grid).State = EntityState.Modified;

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!GridExists(id))
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

    [HttpDelete("{id}")]
    public async Task<ActionResult<Grid>> DeleteGrid(int id)
    {
      var grid = await _db.Grids.FindAsync(id);
      if (grid == null)
      {
        return NotFound();
      }

      _db.Grids.Remove(grid);
      await _db.SaveChangesAsync();

      return grid;
    }

    private bool GridExists(int id)
    {
      return _db.Grids.Any(e => e.GridId == id);
    }
  }
}