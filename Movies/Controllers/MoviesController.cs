using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Movies.Models;
using Movies.Models.VM;
using Movies.Services;

namespace Movies.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly IActorService _actorService;
        private readonly IProducerService _producerService;

        public MoviesController(
            IMovieService movieService,
            IActorService actorService,
            IProducerService producerService)
        {
            _movieService = movieService;
            _actorService = actorService;
            _producerService = producerService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_movieService.Get());
        }

        // GET: Movies/Details/5
        [HttpGet]
        public IActionResult Details(int id)
        {
            var movie = _movieService.Get(id);

            if (movie == null)
                return NotFound();

            return View(movie);
        }

        // GET: Movies/Details/5
        [HttpGet]
        public IActionResult ActorDetails(int id)
        {
            var actor = _actorService.Get(id);

            if (actor == null)
                return NotFound();

            return View(actor);
        }

        // GET: Movies/ProducerDetails/5
        [HttpGet]
        public IActionResult ProducerDetails(int id)
        {
            var producer = _producerService.Get(id);

            if (producer == null)
                return NotFound();

            return View(producer);
        }

        // GET: Movies/Create
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.AllActors = _actorService.Get();

            ViewData["ProducerId"] = new SelectList(_producerService.Get(),
                "Id", "Name");

            return View();
        }

        // POST: Movies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MovieVM viewModel, int[] selectedActors)
        {
            // If Modal Validation Fails
            if (!ModelState.IsValid)
            {
                ViewData["ProducerId"] = new SelectList(
                    _producerService.Get(), "Id", "Name",
                    viewModel.ProducerId);
                
                return View(viewModel);
            }
            
            _movieService.Create(viewModel, selectedActors);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult ProducerCreate(Producer viewModel)
        {
            // TODO: Introduce ProducerViewModel instead of expecting Producer directly.
            _producerService.Create(viewModel);
            return RedirectToAction(nameof(Create));
        }

        // GET: Movies/Edit/5
        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (!_movieService.Exist(id))
                return NotFound();

            var (actorList, movie) = _movieService.ActorsList(id);

            ViewData["Actors"] = actorList;

            ViewData["ProducerId"] = new SelectList(_producerService.Get(),
                "Id", "Name", movie.ProducerId);

            return View(movie);
        }

        // POST: Movies/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Movie movie, MovieVM viewModel, int[] selectedActors)
        {
            // BUG: Edit will create a new Movie Entry instead of Updating existing!

            if (ModelState.IsValid)
            {
                ViewData["ProducerId"] = new SelectList(
                    _producerService.Get(), "Id", "Name", movie.ProducerId);
                return View();
            }

            _movieService.Edit(id, movie, viewModel, selectedActors);

            return RedirectToAction(nameof(Index));
        }

        private bool IsMovieExist(int movieId)
        {
            return _movieService.Exist(movieId);
        }
    }
}
