using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HW12.Entities;
using HW12.Entities.HW12.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;



namespace HW12
{
    public class TaskDbContext : DbContext
    {
        public DbSet<Tasktodo> Tasks { get; set; }
        public DbSet<User> Users { get; set; } 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LAPTOP-01HRT8HI\\SQLEXPRESS;Database=TaskDb;Integrated Security=true;TrustServerCertificate=True");
        }

    }
}
