using MyMovies.Data;
using MyMovies.Services.DtoModels;
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
        void Delete(int id);
        void UpdateMovie(Movie movie);
        SideBarData GetSidebarData();
    }
}
