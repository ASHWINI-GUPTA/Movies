using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Movies.Models;
using Movies.Services;

namespace Movies.Controllers.API
{
    [Produces("application/json")]
    [Route("api/Producers")]
    public class ProducersController : Controller
    {
        private readonly IProducerService _producerService;

        public ProducersController(IProducerService producerService)
        {
            _producerService = producerService;
        }

        // POST: api/Producers
        [HttpPost]
        public IActionResult PostProducer([FromForm] Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _producerService.Create(producer);

            return RedirectToAction("Create", new RouteValueDictionary(
                    new { controller = "Movies", action = "Create" }));
        }
    }
}