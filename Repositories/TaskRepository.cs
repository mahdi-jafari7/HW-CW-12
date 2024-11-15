using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HW12.Entities;
using HW12.Entities.HW12.Entities;
using HW12.Enums;
using HW12.Interfaces;

namespace HW12.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskDbContext taskDb;

        public TaskRepository(TaskDbContext taskDb)
        {
            this.taskDb = taskDb;
        }

        public void Add(Tasktodo task)
        {
            taskDb.Add(task);
            taskDb.SaveChanges();
        }

        public Tasktodo GetByID(int id)
        {
            return taskDb.Tasks.Find(id);
        }

        public List<Tasktodo> GetAll(int userId)
        {
            return taskDb.Tasks.Where(t => t.UserId == userId).ToList();
        }

        public void Update(Tasktodo task)
        {
            taskDb.Tasks.Update(task);
            taskDb.SaveChanges();
        }

        public void Delete(int id)
        {
            var task = GetByID(id);
            if (task != null)
            {
                taskDb.Tasks.Remove(task);
                taskDb.SaveChanges();
            }
        }
       
        public IEnumerable<Tasktodo> SearchByTitle(int userId, string title)
        {
            return taskDb.Tasks.Where(x => x.UserId == userId && x.Title.Contains(title)).ToList();
        }

        public void ChangeStatus(int id, StatusEnum status)
        {
            var task = GetByID(id);
            if (task != null)
            {
                task.Status = status;
                taskDb.SaveChanges();
            }
        }
    }
}
