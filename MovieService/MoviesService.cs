using MyMovies.Data;
using MyMovies.Repositories.Interfaces;
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
            var movies = MoviesRepo.GetAll();
            return movies;
        }

        public Movie GetById(int id)
        {
            var movie = MoviesRepo.GetById(id);
            return movie;
        }

        public void CreateMovie(Movie movie)
        {
            MoviesRepo.Add(movie);
        }

        public List<Movie> GetByTitle(string title)
        {
            var movies = MoviesRepo.GetByTitle(title);
            return movies;
        }
        public Movie GetMovieDetails(int id)
        {
            var movie = MoviesRepo.GetById(id);

            movie.Views += 1;
            MoviesRepo.Update(movie);

            return movie;
        }

        public void UpdateMovie(Movie movie)
        {
            MoviesRepo.Update(movie);
        }

        public void Delete(int id)
        {
            MoviesRepo.Delete(id);
        }
    }
}
