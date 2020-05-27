using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyMovies.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [MaxLength(300)]
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        [Required]
        public string Cast { get; set; }

        [Required]
        public string Genre { get; set; }
    }
}
