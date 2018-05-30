using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Movies.Data;
using Movies.Models;
using System.Threading.Tasks;

namespace Movies.Controllers.API
{
    [Produces("application/json")]
    [Route("api/Actors")]
    public class ActorController : Controller
    {
        private readonly DBContext _context;

        public ActorController(DBContext context)
        {
            _context = context;
        }

        // POST: api/Actors
        [HttpPost]
        public async Task<IActionResult> PostActors([FromForm] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Actors.Add(actor);
            await _context.SaveChangesAsync();

            return RedirectToAction("Create", new RouteValueDictionary(
                        new { controller = "Movies", action = "Create" }));
        }
    }
}
