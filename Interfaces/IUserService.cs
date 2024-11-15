using HW12.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW12.Interfaces
{
    public interface IUserService
    {
        void AddUser(string username, string password);
        IEnumerable<User> GetAllUsers();
        User GetUserByID(int id);
        void UpdateUser(int id, string username, string password);
        void DeleteUser(int id);
        public User Login(string username, string password);

    }
}