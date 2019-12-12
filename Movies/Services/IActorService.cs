using System.Collections.Generic;
using Movies.Models;

namespace Movies.Services
{
    public interface IActorService
    {
        IList<Actor> Get();
        Actor Get(in int id);
        void Create(Actor actor);
    }
}
