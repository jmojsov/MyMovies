using MyMovies.Data;
using System.Collections.Generic;

namespace MyMovies.Services.Interfaces
{
    public interface IMoviesService
    {
        List<Movie> GetAll();
        List<Movie> GetByTitle(string title);
        Movie GetById(int id);
        void CreateMovie(Movie movie);
        Movie GetMovieDetails(int id);
        void UpdateMovie(Movie movie);
        void Delete(int id);
    }
}

