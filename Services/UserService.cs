using HW12.Entities;
using HW12.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW12.Services
{

    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;

        public UserService(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public void AddUser(string username, string password)
        {
            var newUser = new User
            {
                Username = username,
                Password = password
            };

            _userRepo.Add(newUser);
        }

        public User Login(string username, string password)
        {
            return _userRepo.GetAll().FirstOrDefault(u => u.Username == username && u.Password == password);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _userRepo.GetAll();
        }

        public User GetUserByID(int id)
        {
            return _userRepo.GetByID(id);
        }

        public void UpdateUser(int id, string username, string password)
        {
            var user = _userRepo.GetByID(id);
            if (user != null)
            {
                user.Username = username;
                user.Password = password;
                _userRepo.Update(user);
            }
        }

        public void DeleteUser(int id)
        {
            _userRepo.Delete(id);
        }
    }
}




