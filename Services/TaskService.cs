using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HW12.Entities;
using HW12.Entities.HW12.Entities;
using HW12.Enums;
using HW12.Interfaces;

namespace HW12.Services
{
    public class TaskService : ITaskSevice
    {
        private readonly ITaskRepository _taskRepo;

        public TaskService(ITaskRepository taskRepo)
        {
            _taskRepo = taskRepo;
        }

        public void AddTask(string title, string description, DateTime time, int status, int priority, int userId)
        {
            var newTask = new Tasktodo
            {
                Title = title,
                Description = description,
                Deadline = time,
                Status = (StatusEnum)status,
                Priority = (PriorityEnum)priority,
                UserId = userId
            };

            _taskRepo.Add(newTask);
        }

        public IEnumerable<Tasktodo> GetTasksByDeadline(int userId)
        {
            return _taskRepo.GetAll(userId).OrderBy(t => t.Deadline);
        }

        public IEnumerable<Tasktodo> GetTasksByPriority(int userId)
        {
            return _taskRepo.GetAll(userId).OrderBy(t => t.Priority);
        }

        public IEnumerable<Tasktodo> GetTasksByStatus(int userId)
        {
            return _taskRepo.GetAll(userId).OrderBy(t => t.Status);
        }

        public IEnumerable<Tasktodo> SearchTasks(int userId, string title)
        {
            return _taskRepo.SearchByTitle(userId, title);
        }

        public void UpdateTask(int id, string title, string description, DateTime time, int status, int priority)
        {
            var task = _taskRepo.GetByID(id);
            if (task != null)
            {
                task.Title = title;
                task.Description = description;
                task.Deadline = time;
                task.Status = (StatusEnum)status;
                task.Priority = (PriorityEnum)priority;
                _taskRepo.Update(task);
            }
        }

        public void DeleteTask(int id)
        {
            _taskRepo.Delete(id);
        }

        public void ChangeTaskStatus(int id, int status)
        {
            _taskRepo.ChangeStatus(id, (StatusEnum)status);
        }
    }
}
