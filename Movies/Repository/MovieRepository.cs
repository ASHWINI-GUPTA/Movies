using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Movies.Data;
using Movies.Models;

namespace Movies.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly DBContext _context;

        public MovieRepository(DBContext context)
        {
            _context = context;
        }

        public IEnumerable<Movie> Get()
        {
            return _context.Movies
                .Include(m => m.Producer)
                .AsNoTracking();
        }

        public Movie Get(int id)
        {
            return _context.Movies
                .Include(m => m.Producer)
                .Include(a => a.ActorMovies)
                .ThenInclude(ma => ma.Actor)
                .AsNoTracking()
                .SingleOrDefault(m => m.MovieId == id);
        }

        public void Create(Movie movie)
        {
            _context.Add(movie);
        }

        public void InsertActor(ActorMovie actorMovieVm)
        {
            _context.Add(actorMovieVm);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public bool Exist(int id)
        {
            return _context.Movies.Any(e => e.MovieId == id);
        }

        public void UpdateActor(ActorMovie actorMovieVm)
        {
            _context.Update(actorMovieVm);
        }

        public void Update(Movie editMovie)
        {
            _context.Update(editMovie);
            _context.SaveChanges();
        }
    }
}
