using MyMovies.Data;
using MyMovies.Repositories;
using MyMovies.Repositories.Interfaces;
using MyMovies.Services.DtoModels;
using MyMovies.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovies.Services
{
    public class UsersService : IUsersService
    {
        public UsersService(IUserRepository userRepository)
        {
            UserRepository = userRepository;
        }

        public IUserRepository UserRepository { get; }



        public List<User> GetAll()
        {
          
            var users = UserRepository.GetAll();
            return users;
        }
        public void Delete(int id)
        {
            UserRepository.Delete(id);
        }

        public User GetById(int id)
        {
            return UserRepository.GetById(id);
        }

        public ModifyUserResult ModifyUser(User user)
        {
            var result = new ModifyUserResult();

            var currentUser = UserRepository.GetByUsername(user.Username);

            if (currentUser == null || currentUser.Id == user.Id)
            {
                var dbUser = UserRepository.GetById(user.Id);

                dbUser.Username = user.Username;
                dbUser.IsAdmin = user.IsAdmin;

                UserRepository.Update(dbUser);
                result.Status = true;
            }
            else
            {
                result.Status = false;
                result.Message = "User already exists";
            }

            return result;

        }

        public void ChangePassword(int id, string password)
        {
            var user = UserRepository.GetById(id);

            user.Password = BCrypt.Net.BCrypt.HashPassword(password);
            UserRepository.Update(user);
        }

        public string CreateUser(string username, string password, bool isAdmin)
        {
            string message = null;

            var user = UserRepository.GetByUsername(username);

            if (user == null)
            {
                var newUser = new User();

                newUser.Username = username;
                newUser.Password = BCrypt.Net.BCrypt.HashPassword(password);
                newUser.IsAdmin = isAdmin;

                UserRepository.Add(newUser);

                return message;
            }
            else
            {
                message = "user already ecists";

                return message;
            }
        }

        public User GetByUsername(string username)
        {
            return UserRepository.GetByUsername(username);
        }
    }
}
