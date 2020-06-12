using MyMovies.Data;
using MyMovies.Repositories.Interfaces;
using MyMovies.Services.DtoModels;
using MyMovies.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

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
        public void GetSidebarData()
        {
            //get all movies

            var movies = MoviesRepo.GetAll();

            // order all movies by views and take 5


            var topFive = movies.OrderByDescending(x => x.Views).Take(5).ToList();


            //order movies by date created and take 5
            var last5 = movies.OrderByDescending(x => x.DateCreated).Take(5).ToList();


            // return movies

        }

        SideBarData IMoviesService.GetSidebarData()
        {
            var movies = MoviesRepo.GetAll();

            var topMovies = movies
                .OrderBy(x => x.Views)
                .Take(5)
                .Select(x => new SidebarMovie()
                {
                    Id = x.Id,
                    Title = x.Title,
                    DateCreated = x.DateCreated.Value,
                    Views = x.Views
                })
                .ToList();

            var recentMovies = movies
                .OrderBy(x => x.DateCreated)
                .Take(5)
                .Select(x => new SidebarMovie()
                {
                    Id = x.Id,
                    Title = x.Title,
                    DateCreated = x.DateCreated.Value,
                    Views = x.Views
                })
                .ToList();

            var sidebarData = new SideBarData();
            sidebarData.TopMovies = topMovies;
            sidebarData.RecentMovies = recentMovies;

            return sidebarData;
        }
    }
}
