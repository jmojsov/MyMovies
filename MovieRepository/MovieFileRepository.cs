using MyMovies.Models;
using MyMovies.Repository.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MyMovies.Repository
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
    }
}