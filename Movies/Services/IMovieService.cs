using System.Collections.Generic;
using Movies.Models;
using Movies.Models.VM;

namespace Movies.Services
{
    public interface IMovieService
    {
        List<Movie> Get();
        Movie Get(int id);
        void Create(Movie movie);
        void Create(MovieVM viewModel, int[] selectedActors);
        bool Exist(int id);
        (IEnumerable<EditMovieVM>, Movie) ActorsList(int id);
        void Edit(int id, Movie movie, MovieVM viewModel, int[] selectedActors);
    }
}
