using MyMovies.Models;
using MyMovies.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MyMovies.Repositories
{
    public class MovieSqlRepository : IMovieRepository
    {
       
        public void Add(Movie movie)
        {

            using (var cnn = new SqlConnection("Data Source=. \\ SQLEXPRESS; Initial Catalog = MyMoviesSQL; Integrated Security = true"))
            {
                cnn.Open();

                var query = @"insert into Movies (Title, Description, ImageUrl, Cast, Genre)
                               values(@Title, @Description, @ImageUrl, @Cast, @Genre)";

                var cmd = new SqlCommand(query, cnn);
                cmd.Parameters.AddWithValue("@Title", movie.Title);
                cmd.Parameters.AddWithValue("@Description", movie.Description);
                cmd.Parameters.AddWithValue("@ImageUrl", movie.ImageUrl);
                cmd.Parameters.AddWithValue("@Cast", movie.Cast);
                cmd.Parameters.AddWithValue("@Genre", movie.Genre);

                cmd.ExecuteNonQuery();


            }
        }

        public List<Movie> GetAll()
        {
            var result = new List<Movie>();
            using(var cnn = new SqlConnection("Data Source=.\\SQLlEXPRESS; Initial Catalog = MyMoviesSQL; Integrated Security = true"))
            {
                cnn.Open();

                var cmd = new SqlCommand("Select * from Movies", cnn);

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var movie = new Movie();

                    movie.Id = reader.GetInt32(0);
                    movie.Title = reader.GetString(1);
                    movie.Description = reader.GetString(2);
                    movie.ImageUrl = reader.GetString(3);
                    movie.Cast = reader.GetString(4);
                    movie.Genre = reader.GetString(5);

                    result.Add(movie);
                }
            }
            return result;
        }

        public Movie GetById(int id)
        {
            Movie result = null;

            using (var cnn = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog = MyMoviesSQL; Integrated Security = true"))
            {
                cnn.Open();

                var cmd = new SqlCommand($"Select * from Movies where id = @Id", cnn);
                cmd.Parameters.AddWithValue("@Id", id);

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result = new Movie();

                    result.Id = reader.GetInt32(0);
                    result.Title = reader.GetString(1);
                    result.Description = reader.GetString(2);
                    result.ImageUrl = reader.GetString(3);
                    result.Cast = reader.GetString(4);
                    result.Genre = reader.GetString(5);
                }
            }
            return result;
        }

        public List<Movie> GetByTitle(string title)
        {
            var result = new List<Movie>();

            using (var cnn = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog = MyMoviesSQL; Integrated Security = true"))
            {
                cnn.Open();

                var query = "SELECT * FROM Movies";

                if (!String.IsNullOrEmpty(title))
                {
                    query = $"{query} where title like @title";
                }

                var cmd = new SqlCommand(query, cnn);

                if (!String.IsNullOrEmpty(title))
                {
                    cmd.Parameters.AddWithValue("@title", $"%{title}%");
                }

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var movie = new Movie();

                    movie.Id = reader.GetInt32(0);
                    movie.Title = reader.GetString(1);
                    movie.Description = reader.GetString(2);
                    movie.ImageUrl = reader.GetString(3);
                    movie.Cast = reader.GetString(4);
                    movie.Genre = reader.GetString(5);

                    result.Add(movie);
                }
            }

            return result;
        }
    }
}
