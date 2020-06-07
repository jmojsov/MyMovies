using MyMovies.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovies.Repositories.Interfaces
{
    public interface IUserRepository
    {
        User GetByUsername(string username);
        void Add(User newUser);
    }
}
