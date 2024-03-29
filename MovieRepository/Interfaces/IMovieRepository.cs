﻿using MyMovies.Data;
using System.Collections.Generic;

namespace MyMovies.Repositories.Interfaces
{
    public interface IMovieRepository
    {
        List<Movie> GetAll();
        List<Movie> GetByTitle(string title);
        Movie GetById(int id);
        void Add(Movie movie);
        void Update(Movie movie);
        void Delete(int id);
    }
}