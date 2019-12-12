using System.Collections.Generic;
using Movies.Models;

namespace Movies.Repository
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> Get();
        Movie Get(int id);
        void Create(Movie movie);
        void InsertActor(ActorMovie actorMovieVm);
        void SaveChanges();
        bool Exist(int id);
        void UpdateActor(ActorMovie actorMovieVm);
        void Update(Movie editMovie);
    }
}
