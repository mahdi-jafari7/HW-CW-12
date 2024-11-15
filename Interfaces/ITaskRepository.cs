using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HW12.Entities;
using HW12.Entities.HW12.Entities;
using HW12.Enums;

namespace HW12.Interfaces
{
    public interface ITaskRepository
    {
        public void Add(Tasktodo task);
        public Tasktodo GetByID(int id);
        public List<Tasktodo> GetAll(int userId);
        public void Update(Tasktodo task);
        public void Delete(int id);
        public IEnumerable<Tasktodo> SearchByTitle(int userId, string title);
        public void ChangeStatus(int id, StatusEnum status);


    }
}
