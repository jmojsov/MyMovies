using MyMovies.Models;
using System.Collections.Generic;

namespace MyMovies.Repository.Interfaces
{
    public interface IMovieRepository
    {
        List<Movie> GetAll();

        Movie GetById(int id);
    }
}