using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Movies.Data;
using Movies.Models;

namespace Movies.Controllers.API
{
    [Produces("application/json")]
    [Route("api/Producers")]
    public class ProducersController : Controller
    {
        private readonly DBContext _context;

        public ProducersController(DBContext context)
        {
            _context = context;
        }

        // POST: api/Producers
        [HttpPost]
        public async Task<IActionResult> PostProducer([FromForm] Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Producers.Add(producer);
            await _context.SaveChangesAsync();

            return RedirectToAction("Create", new RouteValueDictionary(
                    new { controller = "Movies", action = "Create" }));
        }
    }
}