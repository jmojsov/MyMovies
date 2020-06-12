using MyMovies.Data;
using MyMovies.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovies.Repositories
{
    public class MovieCommentRepository : IMovieCommentRepository
    {
        private MyMoviesContext Context { get; set; }
        public MovieCommentRepository(MyMoviesContext context)
        {
            Context = context;
        }


        public void Add(MovieComment comment)
        {
            Context.Add(comment);
            Context.SaveChanges();
        }
    }
}
