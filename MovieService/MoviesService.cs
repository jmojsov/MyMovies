using MyMovies.Models;
using MyMovies.Repository.Interfaces;
using MyMovies.Services.Interfaces;
using System.Collections.Generic;

namespace MyMovies.Services
{
    public class MoviesService : IMoviesService
    {
        public IMovieRepository MoviesRepo { get; set; }

        public MoviesService(IMovieRepository moviesRepo)
        {
            MoviesRepo = moviesRepo;
        }

        public List<Movie> GetAll()
        {
            var movie = MoviesRepo.GetAll();
            return movie;
        }

        public Movie GetById(int id)
        {
            var movie = MoviesRepo.GetById(id);
            return movie;
        }
    }
}
