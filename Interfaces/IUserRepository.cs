using HW12.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW12.Interfaces
{
    public interface IUserRepository
    {
        void Add(User user);
        User GetByID(int id);
        List<User> GetAll();
        void Update(User user);
        void Delete(int id);
    }
}
