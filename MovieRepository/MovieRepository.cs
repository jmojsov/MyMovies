using DocumentFormat.OpenXml.InkML;
using Microsoft.EntityFrameworkCore;
using MyMovies.Data;
using MyMovies.Repositories.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyMovies.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private MyMoviesContext Context { get; set; }
        public MovieRepository(MyMoviesContext context)
        {
            Context = context;
        }
        public void Add(Movie movie)
        {
            movie.DateCreated = DateTime.Now;
            Context.Movies.Add(movie);
            Context.SaveChanges();
        }
        public List<Movie> GetAll()
        {

            return Context.Movies.ToList();
        }
        public Movie GetById(int id)
        {
            return Context.Movies
                .Include(x => x.MovieComments)
                    .ThenInclude(x => x.User)
                .FirstOrDefault(x => x.Id == id);
        }

        

        public List<Movie> GetByTitle(string title)
        {
            var movies = Context.Movies.AsQueryable();

            if (!String.IsNullOrEmpty(title))
            {
                movies = movies.Where(x => x.Title.Contains(title));
            }
            return movies.ToList();
        }

        public void Update(Movie movie)
        {
            Context.Movies.Update(movie);
            Context.SaveChanges();
        }

        public void Delete(int id)
        {
            var movie = new Movie()
            {
                Id = id
            };

            Context.Remove(movie);
            Context.SaveChanges();

        }

    }
}
