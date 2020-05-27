using MyMovies.Models;
using MyMovies.Repositories.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MyMovies.Repositories
{
    public class MovieFileRepository : IMovieRepository
    {
        public List<Movie> Movies { get; set; }

        public MovieFileRepository()
        {
            var movies = File.ReadAllText("movies.txt");

            Movies = JsonConvert.DeserializeObject<List<Movie>>(movies);
        }

        public List<Movie> GetAll()
        {
            return Movies;
        }

        public Movie GetById(int id)
        {
            return Movies.FirstOrDefault(x => x.Id == id);
        }
        public void Add(Movie movie)
        {
            var movies = GetAll();
            var maxId = movies.Max(x => x.Id);
            movie.Id = maxId + 1;


            Movies.Add(movie);

            var json = JsonConvert.SerializeObject(movie);

            File.WriteAllText("movies.txt", json);
        }

        public List<Movie> GetByTitle(string title)
        {
            throw new NotImplementedException();
        }
    }
}