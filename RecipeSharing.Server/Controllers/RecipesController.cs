using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipeSharing.Server.Data;
using RecipeSharing.Server.Models;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeSharing.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RecipesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<RecipeModel>>> GetRecipe()
        {
            return await _context.Recipes.ToListAsync();
        }

        [HttpGet("id")]
        [AllowAnonymous]
        public async Task<ActionResult<RecipeModel>> GetRecipe(int id)
        {
            var recipe = await _context.Recipes.FindAsync(id);

            if (recipe == null)
            {
                return NotFound();
            }

            return recipe;
        }

        [HttpPost]
        public async Task<ActionResult<RecipeModel>> PostRecipe(RecipeModel recipe)
        {
            _context.Recipes.Add(recipe);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRecipe), new { id = recipe.Id }, recipe);
        }

        public async Task<IActionResult> PutRecipe(int id, RecipeModel recipe)
        {
            if (id != recipe.Id)
            {
                return BadRequest();
            }

            _context.Entry(recipe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecipeExists(id))
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
        [HttpDelete]
        public async Task<IActionResult> DeleteRecipe(int id)
        {
            var recipe = await _context.Recipes.FindAsync(id);
            if (recipe == null)
            {
                return NotFound();
            }

            _context.Recipes.Remove(recipe);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RecipeExists(int id)
        {
            return _context.Recipes.Any(r => r.Id == id);
        }
    }
}
