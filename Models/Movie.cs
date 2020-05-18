using System;
using System.Collections.Generic;

namespace MyMovies.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public string Cast { get; set; }
        public string Genre { get; set; }
    }
}
