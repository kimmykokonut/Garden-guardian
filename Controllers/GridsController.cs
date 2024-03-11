using Microsoft.AspNetCore.Mvc;
using GardenApi.Models;
using Microsoft.EntityFrameworkCore;

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
    public async Task<ActionResult<IEnumerable<Grid>>> GetGrids()
    {
      return await _db.Grids.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Grid>> GetGrid(int id)
    {
      Grid grid = await _db.Grids
          .Include(grid => grid.Garden)
          .Include(g => g.GridSeeds)
          .ThenInclude(gs => gs.Seed)
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
    public async Task<IActionResult> PutGrid(int id, Grid grid)
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
    [HttpPost("AddSeed")]
    public async Task<IActionResult> AddSeed(Grid grid, int seedId)
    {
#nullable enable
      GridSeed? joinEnt = await _db.GridSeeds.FirstOrDefaultAsync(join => join.SeedId == seedId && join.GridId == grid.GridId);
#nullable disable
      if (joinEnt == null && seedId != 0)
      {
        _db.GridSeeds.Add(new GridSeed() { SeedId = seedId, GridId = grid.GridId });
        await _db.SaveChangesAsync();
      }
      return NoContent();
    }
  }
}