using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Movies.Data;
using Movies.Models;
using Movies.Models.VM;

namespace Movies.Controllers
{
    public class MoviesController : Controller
    {
        private readonly DBContext _context;

        public MoviesController(DBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var dBContext = _context.Movies
                .Include(m => m.Producer);

            return View(dBContext.ToList());
        }

        // GET: Movies/Details/5
        [HttpGet]
        public IActionResult Details(int movieId)
        {
            var movie = _context.Movies
                .Include(m => m.Producer)
                .Include(a => a.ActorMovies)
                .ThenInclude(ma => ma.Actor)
                .SingleOrDefault(m => m.MovieId == movieId);

            if (movie == null)
                return NotFound();

            return View(movie);
        }

        // GET: Movies/Details/5
        [HttpGet]
        public IActionResult ActorDetails(int id)
        {
            var actor = _context.Actors
                .SingleOrDefault(m => m.ActorId == id);

            if (actor == null)
                return NotFound();

            return View(actor);
        }

        // GET: Movies/ProducerDetails/5
        [HttpGet]
        public IActionResult ProducerDetails(int id)
        {
            var producer = _context.Producers
                .SingleOrDefault(m => m.Id == id);

            if (producer == null)
                return NotFound();

            return View(producer);
        }

        // GET: Movies/Create
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.AllActors = _context.Actors.ToList();
            ViewData["ProducerId"] = new SelectList(_context.Producers, "Id", "Name");
            return View();
        }

        // POST: Movies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MovieVM viewModel, int[] selectedActors)
        {
            // If Modal Validation Fails
            if (!ModelState.IsValid)
            {
                ViewData["ProducerId"] = new SelectList(
                    _context.Producers, "Id", "Name", viewModel.ProducerId);
                
                return View(viewModel);
            }

            var movie = new Movie
            {
                MovieName = viewModel.MovieName,
                Released = viewModel.Released,
                Plot = viewModel.Plot,
                Poster = viewModel.Poster,
                ProducerId = viewModel.ProducerId
            };

            _context.Add(movie);

            if (selectedActors != null)
            {
                foreach (var item in selectedActors)
                {
                    Actor actor = _context.Actors.Find(item);

                    var actorMovieVM = new ActorMovie
                    {
                        MovieId = movie.MovieId,
                        ActorId = actor.ActorId
                    };

                    _context.Add(actorMovieVM);
                }
            }

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> ProducerCreate(Producer viewModel)
        {
            _context.Add(viewModel);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Create));
        }

        // GET: Movies/Edit/5
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var movie = _context.Movies.Include(m => m.ActorMovies)
                .SingleOrDefault(m => m.MovieId == id);

            if (movie == null)
                return NotFound();

            var actors = _context.Actors.ToList();
            var movieActor = new List<int>(movie.ActorMovies.Select(c => c.ActorId));
            var viewModel = actors.Select(actor => 
                new EditMovieVM
                {
                    ActorId = actor.ActorId, 
                    Name = actor.Name, 
                    InMovie = movieActor.Contains(actor.ActorId)
                }).ToList();

            ViewData["Actors"] = viewModel;

            ViewData["ProducerId"] = new SelectList(_context.Producers, "Id", "Name", movie.ProducerId);
            return View(movie);
        }

        // POST: Movies/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Movie movie, MovieVM viewModel, int[] selectedActors)
        {
            // BUG: Edit will create a new Movie Entry instead of Updating existing!

            if (ModelState.IsValid)
            {
                ViewData["ProducerId"] = new SelectList(
                    _context.Producers, "Id", "Name", movie.ProducerId);
                return View();
            }

            var editMovie = new Movie
            {
                MovieName = viewModel.MovieName,
                Released = viewModel.Released,
                Plot = viewModel.Plot,
                Poster = viewModel.Poster,
                ProducerId = viewModel.ProducerId
            };

            if (selectedActors != null)
            {
                foreach (var item in selectedActors)
                {
                    Actor actor = _context.Actors.Find(item);

                    var actorMovieVM = new ActorMovie
                    {
                        MovieId = movie.MovieId,
                        ActorId = actor.ActorId
                    };

                    _context.Update(actorMovieVM);
                }
            }

            _context.Update(editMovie);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool IsMovieExist(int movieId)
        {
            return _context.Movies.Any(e => e.MovieId == movieId);
        }
    }
}
