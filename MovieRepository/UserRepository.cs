using MyMovies.Data;
using MyMovies.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyMovies.Repositories
{
    public class UserRepository : IUserRepository
    {
        private MyMoviesContext Context { get; set; }
        public UserRepository(MyMoviesContext context)
        {
            Context = context;
        }
        public User GetByUsername(string username)
        {
            return Context.Users.FirstOrDefault(x => x.Username == username);
        }
    }
}
