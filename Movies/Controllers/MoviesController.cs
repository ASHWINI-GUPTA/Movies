using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        // GET: Movies
        public async Task<IActionResult> Index()
        {
            var dBContext = _context.Movies.Include(m => m.Producer);
            return View(await dBContext.ToListAsync());
        }

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies
                .Include(m => m.Producer)
                .Include(a => a.ActorMovies)
                .SingleOrDefaultAsync(m => m.MovieId == id);

            if (movie == null)
            {
                return NotFound();
            }

            foreach(var item in movie.ActorMovies)
            {
                _context.Actors.Where(a => a.ActorId == item.ActorId).ToList();
            }

            return View(movie);
        }

        // GET: Movies/Details/5
        public async Task<IActionResult> ActorDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actor = await _context.Actors
                .SingleOrDefaultAsync(m => m.ActorId == id);

            if (actor == null)
            {
                return NotFound();
            }

            return View(actor);
        }

        // GET: Movies/ProducerDetails/5
        public async Task<IActionResult> ProducerDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producer = await _context.Producers
                .SingleOrDefaultAsync(m => m.Id == id);

            if (producer == null)
            {
                return NotFound();
            }

            return View(producer);
        }
        // GET: Movies/Create
        public IActionResult Create()
        {
            ViewBag.AllActors = _context.Actors.ToList();
            ViewData["ProducerId"] = new SelectList(_context.Producers, "Id", "Name");
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MovieVM viewModel, int[] selectedActors)
        {
            if (ModelState.IsValid)
            {
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
            ViewData["ProducerId"] = new SelectList(_context.Producers, "Id", "Name", viewModel.ProducerId);
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> ProducerCreate(Producer viewModel)
        {
            _context.Add(viewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Create));
        }

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies.Include(m => m.ActorMovies).SingleOrDefaultAsync(m => m.MovieId == id);
            if (movie == null)
            {
                return NotFound();
            }

            var actors = _context.Actors.ToList();
            var movieActor = new List<int>(movie.ActorMovies.Select(c => c.ActorId));
            var viewModel = new List<EditMovieVM>();

            foreach (var actor in actors)
            {
                viewModel.Add(new EditMovieVM
                {
                    ActorId = actor.ActorId,
                    Name = actor.Name,
                    InMovie = movieActor.Contains(actor.ActorId)
                });
            }
            ViewData["Actors"] = viewModel;

            ViewData["ProducerId"] = new SelectList(_context.Producers, "Id", "Name", movie.ProducerId);
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Movie movie, MovieVM viewModel, int[] selectedActors)
        {
            if (ModelState.IsValid)
            {
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
                
            ViewData["ProducerId"] = new SelectList(_context.Producers, "Id", "Name", movie.ProducerId);
            return View();
        }

        private bool MovieExists(int id)
        {
            return _context.Movies.Any(e => e.MovieId == id);
        }
    }
}
