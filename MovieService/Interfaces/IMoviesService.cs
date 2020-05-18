using MyMovies.Models;
using System.Collections.Generic;

namespace MyMovies.Services.Interfaces
{
    public interface IMoviesService
    {
        List<Movie> GetAll();
        Movie GetById(int id);
    }
}

