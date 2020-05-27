using MyMovies.Models;
using System.Collections.Generic;

namespace MyMovies.Services.Interfaces
{
    public interface IMoviesService
    {
        List<Movie> GetAll();
        List<Movie> GetByTitle(string title);
        Movie GetById(int id);
        void CreateMovie(Movie movie);
    }
}

