using HW12.Entities;
using HW12.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW12.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TaskDbContext taskDb;

        public UserRepository(TaskDbContext taskDb)
        {
            this.taskDb = taskDb;
        }

        public void Add(User user)
        {
            taskDb.Users.Add(user);
            taskDb.SaveChanges();
        }

        public User GetByID(int id)
        {
            return taskDb.Users.Find(id);
        }

        public List<User> GetAll()
        {
            return taskDb.Users.ToList();
        }

        public void Update(User user)
        {
            taskDb.Users.Update(user);
            taskDb.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = GetByID(id);
            if (user != null)
            {
                taskDb.Users.Remove(user);
                taskDb.SaveChanges();
            }
        }

        public User Login(string username, string password)
        {
            return taskDb.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
        }
    }
}
