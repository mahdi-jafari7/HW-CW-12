using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HW12.Entities;
using HW12.Enums;
using HW12.Interfaces;

namespace HW12.Entities
{
    namespace HW12.Entities
    {
        public class Tasktodo
        {
            [Key]
            public int Id { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public DateTime Deadline { get; set; }
            public StatusEnum Status { get; set; }
            public PriorityEnum Priority { get; set; }

            public int UserId { get; set; }
            public User User { get; set; }
        }
    }

}



