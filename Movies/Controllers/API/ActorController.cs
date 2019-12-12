using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Movies.Models;
using Movies.Services;

namespace Movies.Controllers.API
{
    [Produces("application/json")]
    [Route("api/Actors")]
    public class ActorController : Controller
    {
        private readonly IActorService _actorService;

        public ActorController(IActorService actorService)
        {
            _actorService = actorService;
        }

        // POST: api/Actors
        [HttpPost]
        public IActionResult PostActors([FromForm] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _actorService.Create(actor);

            return RedirectToAction("Create", new RouteValueDictionary(
                        new { controller = "Movies", action = "Create" }));
        }
    }
}
