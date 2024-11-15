using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HW12.Entities;
using HW12.Entities.HW12.Entities;

namespace HW12.Interfaces
{
    public interface ITaskSevice
    {
        public void AddTask(string title, string description, DateTime time, int status, int priority, int userId);
        public IEnumerable<Tasktodo> GetTasksByDeadline(int userId);
        public IEnumerable<Tasktodo> GetTasksByPriority(int userId);

        public IEnumerable<Tasktodo> GetTasksByStatus(int userId);


        public void UpdateTask(int id, string title, string description, DateTime time, int status, int priority);
        public void DeleteTask(int id);

        public void ChangeTaskStatus(int id, int status);
        public IEnumerable<Tasktodo> SearchTasks(int userId, string title);




    }
}
