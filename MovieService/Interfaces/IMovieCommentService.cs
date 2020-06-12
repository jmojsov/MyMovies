using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovies.Services.Interfaces
{
    public interface IMovieCommentService
    {
        void Add(string comment, int movieId, int userId);
    }
}
