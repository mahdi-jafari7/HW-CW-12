using System;
using System.Collections.Generic;
using System.Linq;
using HW12;
using HW12.Entities;
using HW12.Enums;
using HW12.Interfaces;
using HW12.Repositories;
using HW12.Services;

class Program
{
    static ITaskSevice taskService = new TaskService(new TaskRepository(new TaskDbContext()));
    static IUserService userService = new UserService(new UserRepository(new TaskDbContext()));
    static User currentUser;

    static void Main()
    {
        ShowLoginMenu();
        MainMenu();
    }

    static void ShowLoginMenu()
    {
        while (currentUser == null)
        {
            Console.WriteLine("Welcome to your ToDo List! :)");
            Console.WriteLine("1. Register");
            Console.WriteLine("2. Login");
            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    Register();
                    break;
                case 2:
                    Login();
                    break;
            }
        }
    }

    static void Register()
    {
        Console.Clear();
        Console.WriteLine("Username: ");
        var username = Console.ReadLine();
        Console.WriteLine("Password: ");
        var password = Console.ReadLine();

        userService.AddUser(username, password);
        Console.WriteLine("Registration successful. Please log in.");
    }

    static void Login()
    {
        Console.Clear();
        Console.WriteLine("Username: ");
        var username = Console.ReadLine();
        Console.WriteLine("Password: ");
        var password = Console.ReadLine();

        currentUser = userService.Login(username, password);
        if (currentUser != null)
        {
            Console.WriteLine($"Welcome, {currentUser.Username}!");
        }
        else
        {
            Console.WriteLine("Invalid username or password. Please try again.");
        }
    }

    static void MainMenu()
    {
        Console.WriteLine("Welcome to your todolist");

        while (true)
        {
            Console.WriteLine("1. Add task");
            Console.WriteLine("2. View All Tasks");
            Console.WriteLine("3. Edit task");
            Console.WriteLine("4. Delete task");
            Console.WriteLine("5. Change Task's Status");
            Console.WriteLine("6. Search Tasks");
            Console.WriteLine("7. Logout");
            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    Console.Clear();
                    AddTask();
                    break;
                case 2:
                    Console.Clear();

                    ViewAllTasks();
                    break;
                case 3:
                    Console.Clear();

                    EditTask();
                    break;
                case 4:
                    Console.Clear();

                    DeleteTask();
                    break;
                case 5:
                    Console.Clear();

                    ChangeTaskStatus();
                    break;
                case 6:

                    SearchTasks();
                    break;
                case 7:
                    currentUser = null;
                    ShowLoginMenu();
                    break;
            }
        }
    }

    static void AddTask()
    {
        Console.Clear();
        Console.WriteLine("Title: ");
        var title = Console.ReadLine();
        Console.WriteLine("Description: ");
        var description = Console.ReadLine();
        Console.WriteLine("Deadline: ");
        var time = DateTime.Parse(Console.ReadLine());
        Console.WriteLine("Priority: (High:1, Medium:2, Low:3)");
        int priority = int.Parse(Console.ReadLine());
        Console.WriteLine("Status: (Done:1, Pending:2, Canceled:3)");
        int status = int.Parse(Console.ReadLine());

        taskService.AddTask(title, description, time, status, priority, currentUser.Id);
    }

    static void ViewAllTasks()
    {
        Console.Clear();
        Console.WriteLine("Want to See All Tasks base on what Parameter? Status (Press 1) - Priority (Press 2) - Deadline (Press 3)");
        int option2 = int.Parse(Console.ReadLine());

        switch (option2)
        {
            case 1:
                Console.Clear();
                Console.WriteLine("All Tasks By Status: ");
                foreach (var task in taskService.GetTasksByStatus(currentUser.Id))
                {
                    Console.WriteLine($"{task.Title} - {task.Status}");
                }
                break;
            case 2:
                Console.Clear();
                Console.WriteLine("All Tasks By Priority: ");
                foreach (var task in taskService.GetTasksByPriority(currentUser.Id))
                {
                    Console.WriteLine($"{task.Title} - {task.Priority}");
                }
                break;
            case 3:
                Console.Clear();
                Console.WriteLine("All Tasks By DueTime: ");
                foreach (var task in taskService.GetTasksByDeadline(currentUser.Id))
                {
                    Console.WriteLine($"{task.Title} - {task.Deadline}");
                }
                break;
        }
        Console.WriteLine("Press any button to continue...");
        Console.ReadKey();
    }

    static void EditTask()
    {
        Console.Clear();
        foreach (var task in taskService.GetTasksByStatus(currentUser.Id))
        {
            Console.WriteLine($"{task.Id} - {task.Title}");
        }

        Console.WriteLine("Which Task Do You want To Edit? Enter ID: ");
        int id = int.Parse(Console.ReadLine());

        Console.WriteLine("Title: ");
        var title = Console.ReadLine();
        Console.WriteLine("Description: ");
        var description = Console.ReadLine();
        Console.WriteLine("Deadline: ");
        var time = DateTime.Parse(Console.ReadLine());
        Console.WriteLine("Priority: (High:1, Medium:2, Low:3)");
        int priority = int.Parse(Console.ReadLine());
        Console.WriteLine("Status: (Done:1, Pending:2, Canceled:3)");
        int status = int.Parse(Console.ReadLine());

        taskService.UpdateTask(id, title, description, time, status, priority);
    }

    static void DeleteTask()
    {
        Console.Clear();
        foreach (var task in taskService.GetTasksByStatus(currentUser.Id))
        {
            Console.WriteLine($"{task.Id} - {task.Title}");
        }

        Console.WriteLine("Which Task Do You want To Delete? Enter ID: ");
        int id = int.Parse(Console.ReadLine());

        taskService.DeleteTask(id);
    }

    static void ChangeTaskStatus()
    {
        Console.Clear();
        foreach (var task in taskService.GetTasksByStatus(currentUser.Id))
        {
            Console.WriteLine($"{task.Id} - {task.Title}");
        }

        Console.WriteLine("Which Task's Status Do You want To Change? Enter ID: ");
        int id = int.Parse(Console.ReadLine());

        Console.WriteLine("Status: (Done:1, Pending:2, Canceled:3)");
        int status = int.Parse(Console.ReadLine());

        taskService.ChangeTaskStatus(id, status);
    }

    static void SearchTasks()
    {
        Console.Clear();
        Console.WriteLine("Enter Task Title to Search: ");
        var title = Console.ReadLine();

        var tasks = taskService.SearchTasks(currentUser.Id, title);
        foreach (var task in tasks)
        {
            Console.WriteLine($"{task.Title} - {task.Description}");
        }
    }

    static void AddUser()
    {
        Console.Clear();
        Console.WriteLine("Username: ");
        var username = Console.ReadLine();
        Console.WriteLine("Password: ");
        var password = Console.ReadLine();

        userService.AddUser(username, password);
    }

    static void ViewAllUsers()
    {
        Console.Clear();
        var users = userService.GetAllUsers();
        foreach (var user in users)
        {
            Console.WriteLine($"ID: {user.Id}, Username: {user.Username}");
        }
    }
}