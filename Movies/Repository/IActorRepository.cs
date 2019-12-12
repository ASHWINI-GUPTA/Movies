using System.Collections.Generic;
using Movies.Models;

namespace Movies.Repository
{
    public interface IActorRepository
    {
        IEnumerable<Actor> Get();
        Actor Get(int id);
        void Create(Actor actor);
    }
}
