using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovies.Data
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().HasData(
                new Movie
                {
                    Id = 2,
                    Title = "The Grudge 3 ",
                    Description = "A young Japanese woman who holds the key to stopping the evil spirit of Kayako," +
                    " travels to the haunted Chicago apartment from the sequel, to stop the curse of Kayako once and for all.",
                    ImageUrl = "https://m.media-amazon.com/images/M/MV5BNGU4MThiYjItMDliMC00YWM4LTljZTEtNTg0YzdiMmE2MjM4XkEyXkFqcGdeQXVyMTQxNzMzNDI@._V1_UX182_CR0,0,182,268_AL_.jpg",
                    Cast = "Matthew Knight, Shawnee Smith, Mike Straub  ",
                    Genre = "horror"
                });
        }
    }
}
