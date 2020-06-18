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
        public void Add(User user)
        {
            Context.Users.Add(user);
            Context.SaveChanges();
        }

        public List<User> GetAll()
        {
            return Context.Users.ToList();
        }

        public void Delete(int id)
        {
            var user = new User
            {
                Id = id
            };

            Context.Remove(user);
            Context.SaveChanges();
        }

        public User GetById(int id)
        {
            return Context.Users.FirstOrDefault(x => x.Id == id);
        }

        public void Update(User dbUser)
        {
            Context.Users.Update(dbUser);
            Context.SaveChanges();

        }
    }
}
