using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Movies.Models;
using Movies.Repository;

namespace Movies.Services
{
    public class ActorService : IActorService
    {
        private readonly IActorRepository _actorRepository;

        public ActorService(IActorRepository actorRepository)
        {
            _actorRepository = actorRepository;
        }

        public IList<Actor> Get()
        {
            return _actorRepository.Get().ToList();
        }

        public Actor Get(in int id)
        {
            return _actorRepository.Get(id);
        }

        public void Create(Actor actor)
        {
            _actorRepository.Create(actor);
        }
    }
}
