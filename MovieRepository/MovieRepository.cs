using MyMovies.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyMovies.Repository
{
    public class MovieRepository
    {
        public List<Movie> Movies { get; set; }
        public MovieRepository()
        {
            Movies = new List<Movie>();

            var movie = new Movie()
            {
                Id = 1,
                ImageUrl = "https://m.media-amazon.com/images/M/MV5BMWU0MGYwZWQtMzcwYS00NWVhLTlkZTAtYWVjOTYwZTBhZTBiXkEyXkFqcGdeQXVyMTkxNjUyNQ@@._V1_SY1000_CR0,0,674,1000_AL_.jpg",
                Title = "Bad Boys for Life",
                Description = "Miami detectives Mike Lowrey and Marcus Burnett must face off against a mother-and-son pair of drug lords who wreak vengeful havoc on their city",
                Cast = "Will Smith, Martin Lawrence" ,
                Genre = "action, drama" 

            };

            var movie2 = new Movie()
            {
                Id = 2,
                ImageUrl = "https://m.media-amazon.com/images/M/MV5BNGVjNWI4ZGUtNzE0MS00YTJmLWE0ZDctN2ZiYTk2YmI3NTYyXkEyXkFqcGdeQXVyMTkxNjUyNQ@@._V1_SY1000_CR0,0,674,1000_AL_.jpg",
                Title = "Joker",
                Description = "In Gotham City, mentally troubled comedian Arthur Fleck is disregarded and mistreated by society. He then embarks on a downward spiral of revolution and bloody crime. This path brings him face-to-face with his alter-ego: the Joker.",
                Cast = "Hoaqin Phoenix, Martin Lawrence" ,
                Genre =  "psychological, drama" 

            };

            Movies.Add(movie);
            Movies.Add(movie2); 


        }
        public List<Movie> GetAll()
        {
            var tmp = JsonConvert.SerializeObject(Movies);

            return Movies;
        }
        public Movie GetById(int id)
        {
            return Movies.FirstOrDefault(x => x.Id == id);
        }
    }
}
