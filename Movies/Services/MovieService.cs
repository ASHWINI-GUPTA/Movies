using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Movies.Models;
using Movies.Models.VM;
using Movies.Repository;

namespace Movies.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IActorRepository _actorRepository;
        private readonly IProducerRepository _producerRepository;

        public MovieService(
            IMovieRepository movieRepository,
            IActorRepository actorRepository,
            IProducerRepository producerRepository)
        {
            _movieRepository = movieRepository;
            _actorRepository = actorRepository;
            _producerRepository = producerRepository;
        }

        public List<Movie> Get()
        {
            return _movieRepository.Get().ToList();
        }

        public Movie Get(int id)
        {
            return _movieRepository.Get(id);
        }

        public void Create(Movie movie)
        {
            _movieRepository.Create(movie);
        }

        public void Create(MovieVM viewModel, int[] selectedActors)
        {
            
            var movie = new Movie
            {
                MovieName = viewModel.MovieName,
                Released = viewModel.Released,
                Plot = viewModel.Plot,
                Poster = viewModel.Poster,
                ProducerId = viewModel.ProducerId
            };

            _movieRepository.Create(movie);

            if (selectedActors != null)
            {
                foreach (var item in selectedActors)
                {
                    var actor = _actorRepository.Get(item);

                    var actorMovieVM = new ActorMovie
                    {
                        MovieId = movie.MovieId,
                        ActorId = actor.ActorId
                    };

                    _movieRepository.InsertActor(actorMovieVM);
                }
            }

            _movieRepository.SaveChanges();
        }

        public bool Exist(int id)
        {
            return _movieRepository.Exist(id);
        }

        public (IEnumerable<EditMovieVM>, Movie) ActorsList(int id)
        {
            var movie = _movieRepository.Get(id);
            var actors = _actorRepository.Get();

            var movieActor = new List<int>(movie.ActorMovies.Select(c => c.ActorId));
            var viewModel = actors.Select(actor => 
                new EditMovieVM
                {
                    ActorId = actor.ActorId, 
                    Name = actor.Name, 
                    InMovie = movieActor.Contains(actor.ActorId)
                }).ToList();

            return (viewModel, movie);
        }

        public void Edit(int id, Movie movie, MovieVM viewModel, int[] selectedActors)
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
                    Actor actor = _actorRepository.Get(item);

                    var actorMovieVM = new ActorMovie
                    {
                        MovieId = movie.MovieId,
                        ActorId = actor.ActorId
                    };

                    _movieRepository.UpdateActor(actorMovieVM);
                }
            }

            _movieRepository.Update(editMovie);
        }
    }
}
