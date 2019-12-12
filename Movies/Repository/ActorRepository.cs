using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Movies.Data;
using Movies.Models;

namespace Movies.Repository
{
    public class ActorRepository : IActorRepository
    {
        private readonly DBContext _context;

        public ActorRepository(DBContext context)
        {
            _context = context;
        }

        public IEnumerable<Actor> Get()
        {
            return _context.Actors.AsNoTracking().ToList();
        }

        public Actor Get(int id)
        {
            return _context.Actors.AsNoTracking()
                .SingleOrDefault(m => m.ActorId == id);
        }

        public void Create(Actor actor)
        {
            _context.Actors.Add(actor);
            _context.SaveChanges();
        }
    }
}
